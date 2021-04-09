using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewsLayer
{
    public partial class WebFormClientes : System.Web.UI.Page
    {
        ServiceReference.WebServiceSoapClient Ws = new ServiceReference.WebServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["op"] = "";

                CargarTabla();
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
                DataSet Dts = new DataSet();
                Dts = Ws.GetListClientes("", "", "", "", "G");

                tbl.DataSource = Dts;
                tbl.DataBind();
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
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellido_1.Text = "";
            txtApellido_2.Text = "";

            txtCedula.ReadOnly = false;
            alertModal.Visible = false;
            btnEliminar.Visible = false;

            OnModal(1);
        }

        protected void tblClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = tbl.Rows[tbl.SelectedIndex];

                Session["op"] = "U";
                txtCedula.Text = row.Cells[1].Text;
                txtNombre.Text = row.Cells[2].Text;
                txtApellido_1.Text = row.Cells[3].Text;
                txtApellido_2.Text = row.Cells[4].Text;

                txtCedula.ReadOnly = true;
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

        private String OracleExecute(string op)
        {
            String result = Ws.MaintenanceClientes(txtCedula.Text, txtNombre.Text, txtApellido_1.Text, txtApellido_2.Text, op);
            return result;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string m = "";
            try
            {
                DataSet Dts = new DataSet();
                Dts = Ws.GetListClientes(TextCedula.Text, "", "", "", "F");
                tbl.DataSource = Dts;
                tbl.DataBind();
            }
            catch (Exception es)
            {
                m = es.Message;
                informar(m);
            }
        }

        protected void btnMostraTodo_Click(object sender, EventArgs e)
        {
            string m = "";
            try
            {
                CargarTabla();
                TextCedula.Text = "";
            }
            catch (Exception es)
            {
                m = es.Message;
                informar(m);
            }
        }
    }
}