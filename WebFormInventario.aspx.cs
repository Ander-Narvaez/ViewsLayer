using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewsLayer
{
    public partial class WebFormInventario : System.Web.UI.Page
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
                CargarProveedores();
                CargarArticulo();

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
                int maximos = Convert.ToInt32((String)Session["MAXIMOS"]);
                int minimos = Convert.ToInt32((String)Session["MINIMOS"]);
                int existencias = Convert.ToInt32((String)Session["EXISTENCIAS"]);
                DataSet Dts = new DataSet();
                Dts = Ws.GetListInventario("", "", "", inventario, "",maximos,minimos,existencias, "S");

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

        public void CargarProveedores()
        {
            String m = "";
            try
            {
                DataSet Dts = new DataSet();
                Dts = Ws.GetListProveedores("", "", "", "", "", "", "", "S");

                txtProveedor.Items.Clear();
                txtProveedor.DataSource = Dts;
                txtProveedor.Items.Add(new ListItem(""));
                txtProveedor.DataTextField = "RAZON_SOCIAL";
                txtProveedor.DataBind();
            }
            catch (Exception es)
            {
                m = es.Message;
                informar(m);
            }
        }

        public void CargarArticulo()
        {
            String m = "";
            try
            {
                decimal precio = Convert.ToDecimal((String)Session["PRECIO"]);
                DataSet Dts = new DataSet();
                Dts = Ws.GetListArticulo("", "", "", precio, "S");

                txtArticulo.Items.Clear();
                txtArticulo.DataSource = Dts;
                txtArticulo.Items.Add(new ListItem(""));
                txtArticulo.DataTextField = "ARTICULO";
                txtArticulo.DataBind();
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
            txtInventario.Text = "";
            txtMaximos.Text = "";
            txtMinimos.Text = "";
            txtExistencias.Text = "";

            alertModal.Visible = false;
            btnEliminar.Visible = false;

            OnModal(1);
        }

        protected void tblInventario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = tbl.Rows[tbl.SelectedIndex];

                Session["op"] = "U";
                ListItem item1 = txtEmpresa.Items.FindByValue(row.Cells[1].Text);
                txtEmpresa.SelectedIndex = txtEmpresa.Items.IndexOf(item1);
                ListItem item2 = txtSucursal.Items.FindByValue(row.Cells[3].Text);
                txtSucursal.SelectedIndex = txtSucursal.Items.IndexOf(item2);
                ListItem item3 = txtProveedor.Items.FindByValue(row.Cells[5].Text);
                txtProveedor.SelectedIndex = txtProveedor.Items.IndexOf(item3);
                txtInventario.Text = row.Cells[7].Text;
                ListItem item4 = txtArticulo.Items.FindByValue(row.Cells[8].Text);
                txtArticulo.SelectedIndex = txtArticulo.Items.IndexOf(item4);
                txtMaximos.Text = row.Cells[10].Text;
                txtMinimos.Text = row.Cells[11].Text;
                txtExistencias.Text = row.Cells[12].Text;

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
            String result = Ws.MaintenanceInventario(txtEmpresa.SelectedValue.ToString(), txtSucursal.SelectedValue.ToString(), txtProveedor.SelectedValue.ToString(), parse(txtInventario.Text), txtArticulo.SelectedValue.ToString(), parse(txtMaximos.Text), parse(txtMinimos.Text), parse(txtExistencias.Text), op);
            return result;

        }
    }
}