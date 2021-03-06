using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewsLayer
{
    public partial class WebFormArticulo : System.Web.UI.Page
    {
        ServiceReference.WebServiceSoapClient Ws = new ServiceReference.WebServiceSoapClient();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["op"] = "";

                CargarTabla();
                CargarCategoria();
            }
            else
            {
            }
            CargarTabla();
        }

        public void informar(String m)
        {
            AlertFooter.Visible = true;
            informacion.Text = m;
            informacion.DataBind();
        }


        public void CargarTabla()
        {
            string m = "";
            try
            {
                decimal precio = Convert.ToDecimal((String)Session["PRECIO"]);
                DataSet Dts = new DataSet();
                Dts = Ws.GetListArticulo("", "", "", precio, "S");

                tbl.DataSource = Dts;
                tbl.DataBind();
            }
            catch (Exception es)
            {
                m = es.Message;
                informar(m);
            }
        }

        public void CargarCategoria()
        {
            String m = "";
            try
            {
                DataSet Dts = new DataSet();
                Dts = Ws.GetListCategoria_articulo( "", "", 0 , "S");

                txtCategoria.Items.Clear();
                txtCategoria.DataSource = Dts;
                txtCategoria.Items.Add(new ListItem(""));
                txtCategoria.DataTextField = "CODIGO";
                txtCategoria.DataBind();
            }
            catch (Exception es)
            {
                m = es.Message;
                informar(m);
            }
        }

        public void OnModal(int op)
        {
            if (op == 1)
            {
                string OnModal = "$('#staticBackdrop').modal('show')";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", OnModal, true);
            }
            else if (op == 1)
            {
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Session["op"] = "I";
            txtArticulo.Text = "";
            txtNombre_articulo.Text = "";
            txtCategoria.SelectedIndex = 0;
            txtPrecio.Text = "";

            alertModal.Visible = false;
            btnEliminar.Visible = false;

            OnModal(1);
        }

        protected void tblArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = tbl.Rows[tbl.SelectedIndex];

                Session["op"] = "U";
                txtArticulo.Text = row.Cells[1].Text;
                txtNombre_articulo.Text = row.Cells[2].Text;
                ListItem item1 = txtCategoria.Items.FindByValue(row.Cells[3].Text);
                txtCategoria.SelectedIndex = txtCategoria.Items.IndexOf(item1);
                txtPrecio.Text = row.Cells[5].Text;

                btnEliminar.Visible = true;
                tbl.SelectedIndex = -1;
                alertModal.Visible = false;

                OnModal(1);
            }
            catch (Exception ex)
            {
                informar(ex.Message);
                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            String m = "";
            try
            {
                OracleExecute();
                tbl.SelectedIndex = -1;
                btnEliminar.Visible = true;
                CargarTabla();
            }
            catch (Exception es)
            {
                m = es.Message;
                informar(m);
                OnModal(1);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            String m = "";

            try
            {
                OracleExecute("D");
                CargarTabla();
            }
            catch (Exception es)
            {
                m = es.Message;
                informar(m);
            }
        }

        private String OracleExecute()
        {
            String op = (string)Session["op"];

            return OracleExecute(op);
        }

        private decimal parse(String num)
        {
            try
            {
                return Convert.ToDecimal(num);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private String OracleExecute(string op)
        {
            String result = Ws.MaintenanceArticulo(txtArticulo.Text, txtNombre_articulo.Text, txtCategoria.SelectedValue.ToString(), parse(txtPrecio.Text), op);
            return result;

        }

    }
}