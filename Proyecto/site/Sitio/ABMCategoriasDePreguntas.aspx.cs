using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using EntidadesCompartidas;
using Logica;

public partial class ABMCategoriasDePreguntas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LimpiarFormulario();
    }
    private void LimpiarFormulario()
    {

        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnAgregar.Enabled = false;
        btnBuscar.Enabled = true;

        txtCodigo.Text = "";
        txtCodigo.Enabled = true;
        txtNombre.Text = "";
        txtNombre.Enabled = false;
        lblError.Text = "";

    }
    private void ActivarBotones(bool alta = true)
    {
        btnModificar.Enabled = !alta;
        btnEliminar.Enabled = !alta;
        btnAgregar.Enabled = alta;
        btnBuscar.Enabled = false;

        txtCodigo.Enabled = false;
        txtNombre.Enabled = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {

            string codigo = txtCodigo.Text.Trim();
            Categoria categoria = LogicaCategoria.Buscar(codigo);

            if (categoria != null)
            {
                txtNombre.Text = categoria.Nombre;
                ActivarBotones(false);
                Session["UnaCategoria"] = categoria;

            }
            else
            {

                ActivarBotones();
                lblError.ForeColor = Color.Blue;
                lblError.Text = "No hay categorias registradas con ese valor.";

                Session["UnaCategoria"] = null;
            }

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;

        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try 
        {
            Categoria cat = (Categoria)Session["UnaCategoria"];
            LogicaCategoria.Eliminar(cat);
            lblError.ForeColor = Color.Green;
            lblError.Text = "Eliminacion correcta";
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try 
        {
            string codigo = txtCodigo.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            Categoria cat = new Categoria(codigo, nombre);
            LogicaCategoria.Agregar(cat);
            lblError.ForeColor = Color.Green;
            lblError.Text = "Se agrego la categoria correctamente";
        }
        catch(Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
        
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try 
        {
            Categoria cat = (Categoria)Session["UnaCategoria"];
            cat.Nombre = txtNombre.Text.Trim();
            LogicaCategoria.Modificar(cat);
            lblError.ForeColor = Color.Green;
            lblError.Text = "Se modifico la categoria correctamente";

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarFormulario();
    }
}