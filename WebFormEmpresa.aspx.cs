using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewsLayer
{
    public partial class WebFormEmpresa : System.Web.UI.Page
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
                Dts = Ws.GetListEmpresa("", "", "", "", "", "S");

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
            txtEmpresa.Text = "";
            txtNombre.Text = "";
            txtUbicacion.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";

            alertModal.Visible = false;
            btnEliminar.Visible = false;
            btnSempleadoAgregar.Visible = false;

            OnModal(1);
        }

        protected void tblEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = tbl.Rows[tbl.SelectedIndex];

                Session["op"] = "U";
                txtEmpresa.Text = row.Cells[1].Text;
                txtNombre.Text = row.Cells[2].Text;
                txtUbicacion.Text = row.Cells[3].Text;
                txtEmail.Text = row.Cells[4].Text;
                txtTelefono.Text = row.Cells[5].Text;

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
            String m= "";
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
            String result = Ws.MaintenanceEmpresa1(txtEmpresa.Text, txtNombre.Text,txtUbicacion.Text, txtEmail.Text, txtTelefono.Text, op);
            return result;
        }

        protected void btnSempleadoAgregar_Click(object sender, EventArgs e)
        {
        }
    }
}