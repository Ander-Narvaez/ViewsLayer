using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewsLayer
{
    public partial class WebFormEstante : System.Web.UI.Page
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
                CargarBodega();
                CargarSeccion();
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
                Dts = Ws.GetListEstante("", "", "", "", "", "", "S");

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

        public void CargarBodega()
        {
            String m = "";
            try
            {
                int inventario = Convert.ToInt32((String)Session["INVENTARIO"]);
                DataSet Dts = new DataSet();
                Dts = Ws.GetListBodega("", "", "", inventario, "", "", "S");

                txtBodega.Items.Clear();
                txtBodega.DataSource = Dts;
                txtBodega.Items.Add(new ListItem(""));
                txtBodega.DataTextField = "BODEGA";
                txtBodega.DataBind();
            }
            catch (Exception es)
            {
                m = es.Message;
                informar(m);
            }
        }

        public void CargarSeccion()
        {
            String m = "";
            try
            {
                
                DataSet Dts = new DataSet();
                Dts = Ws.GetListSeccion("", "", "", "", "", "S");

                txtSeccion.Items.Clear();
                txtSeccion.DataSource = Dts;
                txtSeccion.Items.Add(new ListItem(""));
                txtSeccion.DataTextField = "SECCION";
                txtSeccion.DataBind();
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
            txtEstante.Text = "";
            txtDescripcion.Text = "";

            txtEstante.ReadOnly = false;
            alertModal.Visible = false;
            btnEliminar.Visible = false;

            OnModal(1);
        }

        protected void tblEstante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = tbl.Rows[tbl.SelectedIndex];

                Session["op"] = "U";
                ListItem item1 = txtEmpresa.Items.FindByValue(row.Cells[1].Text);
                txtEmpresa.SelectedIndex = txtEmpresa.Items.IndexOf(item1);
                ListItem item2 = txtSucursal.Items.FindByValue(row.Cells[3].Text);
                txtSucursal.SelectedIndex = txtSucursal.Items.IndexOf(item2);
                ListItem item3 = txtBodega.Items.FindByValue(row.Cells[5].Text);
                txtBodega.SelectedIndex = txtBodega.Items.IndexOf(item3);
                ListItem item4 = txtSeccion.Items.FindByValue(row.Cells[7].Text);
                txtSeccion.SelectedIndex = txtSeccion.Items.IndexOf(item4);
                txtEstante.Text = row.Cells[9].Text;
                txtDescripcion.Text = row.Cells[10].Text;

                txtEstante.ReadOnly = true;
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
            String result = Ws.MaintenanceEstante(txtEmpresa.SelectedValue.ToString(), txtSucursal.SelectedValue.ToString(), txtBodega.SelectedValue.ToString(), txtSeccion.SelectedValue.ToString(), txtEstante.Text, txtDescripcion.Text, op);
            return result;
        }
    }
}