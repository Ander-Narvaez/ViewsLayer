using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewsLayer
{
    public partial class WebFormBodega : System.Web.UI.Page
    {
        ServiceReference.WebServiceSoapClient Ws = new ServiceReference.WebServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["op"] = "";

                CargarTabla();
                CargarEmpresa();
                CargarSucursal();
                CargarInventario();
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
                int inventario = Convert.ToInt32((String)Session["INVENTARIO"]);
                DataSet Dts = new DataSet();
                Dts = Ws.GetListBodega("", "", "", inventario, "", "", "S");

                tbl.DataSource = Dts;
                tbl.DataBind();
            }
            catch (Exception es)
            {
                m = es.Message;
                informar(m);
            }
        }

        public void CargarEmpresa()
        {
            String m = "";
            try
            {
                DataSet Dts = new DataSet();
                Dts = Ws.GetListSucursal("", "", "", "", "", "", "S");

                txtEmpresa.Items.Clear();
                txtEmpresa.DataSource = Dts;
                txtEmpresa.Items.Add(new ListItem(""));
                txtEmpresa.DataTextField = "EMPRESA";
                txtEmpresa.DataBind();
            }
            catch (Exception es)
            {
                m = es.Message;
                informar(m);
            }
        }

        public void CargarSucursal()
        {
            String m = "";
            try
            {
                DataSet Dts = new DataSet();
                Dts = Ws.GetListSucursal("", "", "", "", "", "", "S");

                txtSucursal.Items.Clear();
                txtSucursal.DataSource = Dts;
                txtSucursal.Items.Add(new ListItem(""));
                txtSucursal.DataTextField = "SUCURSAL";
                txtSucursal.DataBind();
            }
            catch (Exception es)
            {
                m = es.Message;
                informar(m);
            }
        }

        public void CargarInventario()
        {
            String m = "";
            try
            {
                int inventario = Convert.ToInt32((String)Session["INVENTARIO"]);
                int maximos = Convert.ToInt32((String)Session["MAXIMOS"]);
                int minimos = Convert.ToInt32((String)Session["MINIMOS"]);
                int existencias = Convert.ToInt32((String)Session["EXISTENCIAS"]);
                DataSet Dts = new DataSet();
                Dts = Ws.GetListInventario("", "", "", inventario, "", maximos, minimos, existencias, "S");

                txtSucursal.Items.Clear();
                txtSucursal.DataSource = Dts;
                txtSucursal.Items.Add(new ListItem(""));
                txtSucursal.DataTextField = "INVENTARIO";
                txtSucursal.DataBind();
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
            txtBodega.Text = "";
            txtNombre.Text = "";
            txtUbicacion.Text = "";

            alertModal.Visible = false;
            btnEliminar.Visible = false;

            OnModal(1);
        }

        protected void tblBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = tbl.Rows[tbl.SelectedIndex];

                Session["op"] = "U";
                ListItem item1 = txtEmpresa.Items.FindByValue(row.Cells[1].Text);
                txtEmpresa.SelectedIndex = txtEmpresa.Items.IndexOf(item1);
                ListItem item2 = txtSucursal.Items.FindByValue(row.Cells[3].Text);
                txtSucursal.SelectedIndex = txtSucursal.Items.IndexOf(item2);
                txtBodega.Text = row.Cells[5].Text;
                ListItem item3 = txtInventario.Items.FindByValue(row.Cells[6].Text);
                txtInventario.SelectedIndex = txtInventario.Items.IndexOf(item3);
                txtNombre.Text = row.Cells[8].Text;
                txtUbicacion.Text = row.Cells[9].Text;
                
                

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

        private int parse(String num)
        {
            try
            {
                return Convert.ToInt32(num);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private String OracleExecute(string op)
        {
            String result = Ws.MaintenanceBodega(txtEmpresa.SelectedValue.ToString(), txtSucursal.SelectedValue.ToString(), txtBodega.Text, parse(txtInventario.Text), txtNombre.Text, txtUbicacion.Text, op);
            return result;
        }

    }
}