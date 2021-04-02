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
            String vResfrescarObjeto;
            if (IsPostBack)
            {
                vResfrescarObjeto = "nueva";
            }
            else
            {
                cargarTabla();
            }
        }

        public void cargarTabla()
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
            }
        }

        public void OnModal(int op)
        {
            if (op == 1)
            {
                string encenderModal = "$('#staticBackdrop').modal('show')";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", encenderModal, true);
            }
            else if (op == 1)
            {
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            TxtEMPRESA.Text = "";
            TxtNOMBRE.Text = "";
            TxtUBICACION.Text = "";
            txtEMAIL.Text = "";
            txtTELEFONO.Text = "";

            alertModal.Visible = false;
            btnEliminar.Visible = false;
            btnSempleadoAgregar.Visible = false;

            OnModal(1);
        }

        protected void tblEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = tbl.Rows[tbl.SelectedIndex];
            try
            {
                TxtEMPRESA.Text = row.Cells[1].Text;
                TxtNOMBRE.Text = row.Cells[2].Text;
                TxtUBICACION.Text = row.Cells[3].Text;
                txtEMAIL.Text = row.Cells[4].Text;
                txtTELEFONO.Text = row.Cells[5].Text;
               
                btnEliminar.Visible = true;
                tbl.SelectedIndex = -1;
                alertModal.Visible = false;

                OnModal(1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception)
            {
               
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void btnSempleadoAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}