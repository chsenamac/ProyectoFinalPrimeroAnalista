using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using System.Drawing;

public partial class MasterPageAdministrador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Admin"] != null)
            {
                lblUsuario.Text = "Bienvenido " + ((Administrador)Session["Admin"]).NombreCompleto;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        catch (Exception ex )
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
    
    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Session["Admin"] = null;
        Response.Redirect("Default.aspx");
    }
    protected void lnkButtonAltaAdministrador_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AltaDeUsuarios.aspx");
    }
    protected void lnkButtonABMCategorias_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ABMCategoriasDePreguntas.aspx");
    }
    protected void lnkButtonAltaPreguntas_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AltaDePreguntas.aspx");

    }
    protected void lnkButtonAltaJuegos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AltaDeJuegos.aspx");
    }
    protected void lnkButtonManejoPreguntasJuego_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ManejoDePreguntasDeUnJuego.aspx");
    }
    protected void lnkButtonListadoJuegos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ListadoDeJuegos.aspx");
    }
}
