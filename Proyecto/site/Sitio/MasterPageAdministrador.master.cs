using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class MasterPageAdministrador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] != null)
        {
            lblUsuario.Text = "Bienvenido " + ((Administrador)Session["Admin"]).NombreUsuario;
        }
        else
        {
           Response.Redirect("Default.aspx");
        }
    }
    
    protected void btnSalir_Click(object sender, EventArgs e)
    {
        //Session["Admin"] = null;
        Response.Redirect("Default.aspx");
    }
}
