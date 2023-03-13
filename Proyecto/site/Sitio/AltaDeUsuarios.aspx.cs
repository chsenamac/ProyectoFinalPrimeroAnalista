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
    private void LimpiarFormulario()
    {
        chkPassAdmin.Checked = false;
        chkConfPassAdmin.Checked = false;
        txtNombreUsuario.Text = "";
        txtNombreCompleto.Text = "";
        txtPassUsuario.Text = "";
        txtConfPassUsuario.Text = "";
        txtNombreUsuario.Focus();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        if (!IsPostBack)
        {
            LimpiarFormulario();
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

    protected void chkPassAdmin_CheckedChanged(object sender, EventArgs e)
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
    protected void chkConfPassAdmin_CheckedChanged(object sender, EventArgs e)
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