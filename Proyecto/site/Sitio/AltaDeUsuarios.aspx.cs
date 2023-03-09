using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

using EntidadesCompartidas;
using Logica;

public partial class AltaDeUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        if (!IsPostBack)
        {
            //no se que va aqui, creo que no hay que cargar nada, lo analizare despues
            //cuando haga las pruebas.
        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {

        try
        {
            string pNomUsuario = txtNombreUsuario.Text.Trim();
            string pNomCompleto = txtNombreCompleto.Text.Trim();
            string pPassUsuario = txtPassUsuario.Text.Trim();
            string ConfPassUsuario = txtConfPassUsuario.Text.Trim();

            if (pPassUsuario == ConfPassUsuario)
            {
                Administrador admin = new Administrador(pNomUsuario, pPassUsuario, pNomCompleto);
                LogicaAdministrador.Agregar(admin);

                lblError.ForeColor = Color.Green;
                lblError.Text = "Administrador agregado correctamente.";

            }
            else
            {
                throw new Exception("La contraseña y la confirmación de contraseña no coinciden");
            }

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message; 
        }
    }

    private void LimpiarFormulario()
    {
        txtNombreUsuario.Text = "";
        txtNombreCompleto.Text = "";
        txtPassUsuario.Text = "";
        txtConfPassUsuario.Text = "";
        txtNombreUsuario.Focus();
    }
    protected void imgBtnMostrarPassword_Click(object sender, ImageClickEventArgs e)
    {
        if (txtPassUsuario.TextMode == TextBoxMode.Password)
        {
            txtPassUsuario.TextMode = TextBoxMode.SingleLine;
        }
        else
        {
            txtPassUsuario.TextMode = TextBoxMode.Password;
        }
    }
    
    protected void imgBtnMostrarConfPassword_Click(object sender, ImageClickEventArgs e)
    {
        if (txtConfPassUsuario.TextMode == TextBoxMode.Password)
        {
            txtConfPassUsuario.TextMode = TextBoxMode.SingleLine;
        }
        else
        {
            txtConfPassUsuario.TextMode = TextBoxMode.Password;
        }
    }
}