using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewsLayer
{
    public partial class WebFormSucursal : System.Web.UI.Page
    {
        ServiceReference.WebServiceSoapClient Ws = new ServiceReference.WebServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["op"] = "";

                //CargarTabla();
            }
            else
            {
            }
            //CargarTabla();
        }


        //public void informar(String m)
        //{
        //    AlertFooter.Visible = true;
        //    informacion.Text = m;
        //    informacion.DataBind();
        //}


        //public void CargarTabla()
        //{
        //    string m = "";
        //    try
        //    {
        //        DataSet Dts = new DataSet();
        //        Dts = Ws.GetList("", "", "", "", "", "S");

        //        tbl.DataSource = Dts;
        //        tbl.DataBind();
        //    }
        //    catch (Exception es)
        //    {
        //        m = es.Message;
        //        informar(m);
        //    }
        //}

        //public void OnModal(int op)
        //{
        //    if (op == 1)
        //    {
        //        string OnModal = "$('#staticBackdrop').modal('show')";
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", OnModal, true);
        //    }
        //    else if (op == 1)
        //    {
        //    }
        //}

        protected void btnCrear_Click(object sender, EventArgs e)
        {

        }

        protected void tblSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}