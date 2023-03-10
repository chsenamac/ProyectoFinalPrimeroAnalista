using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

using EntidadesCompartidas;
using Logica;

public partial class AltaDeJuegos : System.Web.UI.Page
{
    private void LimpiarFormulario()
    {
        ddlDificultad.SelectedIndex = 0;
        lblError.Text = "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Administrador admin = (Administrador)Session["Admin"];
            LimpiarFormulario();
            lblAdministrador.Text = admin.NombreCompleto;
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    protected void btnAltaJuego_Click(object sender, EventArgs e)
    {
        try
        {
            Administrador admin = (Administrador)Session["Admin"];
            Juego juego = new Juego(0, DateTime.Now, ddlDificultad.SelectedValue, admin);

            LogicaJuego.Agregar(juego);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Juego agregado correctamente";

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiarFormulario_Click(object sender, EventArgs e)
    {
        LimpiarFormulario();
    }

    protected void btnAsociarPreguntas_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ManejoDePreguntasDeUnJuego.aspx");
    }
}