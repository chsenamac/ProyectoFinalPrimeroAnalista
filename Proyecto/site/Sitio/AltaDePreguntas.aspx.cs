using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

using System.Drawing;

using Logica;
using EntidadesCompartidas;

public partial class AltaDePreguntas : System.Web.UI.Page
{

    private void CargarCategorias()
    {
        try
        {
            List<Categoria> colListaCategorias = LogicaCategoria.Listar();

            if (colListaCategorias.Count == 0)
            {
                throw new Exception("Actualmente no existen categorias ingresadas");
            }

            rblCategorias.Items.Clear();
            rblCategorias.DataSource = colListaCategorias;
            rblCategorias.DataTextField = "rblMostrarCategorias";
            rblCategorias.DataValueField = "codigo";
            rblCategorias.DataBind();

            Session["Categorias"] = colListaCategorias;

            txtTextoPregunta.Focus();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private string GenerarCodigoPregunta()
    {
        string caracteresPermitidos = "^[a-zA-Z0-9]*$";
        string strCodigo;
        char caracter;
        char[] arrCodigo = new char[5];
        Random random = new Random();

        do
        {
            for (int i = 0; i < arrCodigo.Length; i++)
            {
                do
                {
                    caracter = (char)random.Next(0, 128);
                } while (!Regex.IsMatch(caracter.ToString(), caracteresPermitidos));

                arrCodigo[i] = caracter;
            }
            strCodigo = new String(arrCodigo);

        } while (LogicaPregunta.Buscar(strCodigo) != null);

        return strCodigo;
    }

    private void LimpiarFormulario() {
        lblError.Text = "";
        txtTextoPregunta.Text = "";
        txtRespuestaUno.Text = "";
        txtRespuestaDos.Text = "";
        txtRespuestaTres.Text = "";
        rblPuntaje.SelectedIndex = 0;
        rblRespuestaCorrecta.SelectedIndex = 0;
        rblCategorias.SelectedIndex = 0;
        lblCodigoPregunta.ForeColor = Color.DarkOrange;
        lblCodigoPregunta.Text = GenerarCodigoPregunta();
        txtTextoPregunta.Focus();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            CargarCategorias();
        }

        LimpiarFormulario();

    }

    protected void btnAgregarPregunta_Click(object sender, EventArgs e)
    {
        try
        {
            string codigo = lblCodigoPregunta.Text;
            int puntaje = Convert.ToInt32(rblPuntaje.SelectedValue);
            string textoPregunta = txtTextoPregunta.Text;
            int resCorrecta = Convert.ToInt32(rblRespuestaCorrecta.SelectedValue);
            string respuestaUno = txtRespuestaUno.Text;
            string respuestaDos = txtRespuestaDos.Text;
            string respuestaTres = txtRespuestaTres.Text;
            Categoria categoria = null;
            List<Categoria> lista = (List<Categoria>)Session["Categorias"];

            foreach (Categoria cat in lista)
            {
                if (cat.Codigo == rblCategorias.SelectedValue)
                {
                    categoria = cat;
                    break;
                }
            }

            Pregunta pregunta = new Pregunta(codigo, puntaje, textoPregunta, resCorrecta, respuestaUno, respuestaDos, respuestaTres, categoria);
            LogicaPregunta.Agregar(pregunta);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Pregunta agregada correctamente!";
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
}