using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

using EntidadesCompartidas;
using Logica;

public partial class Logueo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Admin"] = null;
        
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            Administrador admin = LogicaAdministrador.Login(txtUsuario.Text.Trim(), txtPassword.Text);
            if (admin != null)
            {
                Session["Admin"] = admin;
                Response.Redirect("~/HomeAdministracion.aspx");
            }
            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Error al inciar sesion, verifique sus credenciales.";
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}