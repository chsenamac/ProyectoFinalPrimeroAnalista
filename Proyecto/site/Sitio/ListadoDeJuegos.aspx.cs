using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using EntidadesCompartidas;
using Logica;

public partial class ListadoDeJuegos : System.Web.UI.Page
{
    private void cargarDDLJuegosPreguntas()
    {
        List<Juego> colListadoJuegos = LogicaJuego.ListarJuegosConPreguntas();

        if (colListadoJuegos.Count == 0)
        {
            throw new Exception("No se encuentran juegos asociados a preguntas");
        }
        else
        {
            ddlJuegos.DataSource = colListadoJuegos;
            ddlJuegos.DataTextField = "DDLMostrarJuegos";
            ddlJuegos.DataValueField = "codigoJuego";
            ddlJuegos.DataBind();
            ddlJuegos.Items.Insert(0, "- Seleccione una opcion");
            
            Session["JuegosPreguntas"] = colListadoJuegos;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargarDDLJuegosPreguntas();
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    protected void btnMostrarResultados_Click(object sender, EventArgs e)
    {
        try
        {
            int codigoJuego = Convert.ToInt32(ddlJuegos.SelectedValue);
            
            List<Jugada> colListarJugadasDeUnJuego = LogicaJugada.ListarJugadasDeUnJuego(codigoJuego);
            List<Pregunta> colPreguntasJuego = LogicaPregunta.ListarPreguntasDeUnJuego(codigoJuego);

            if (colListarJugadasDeUnJuego.Count != 0)
            {
                gvJugadas.DataSource = colListarJugadasDeUnJuego;
                gvJugadas.DataBind();

            }
            else
            {
                gvJugadas.DataSource = null;
                gvJugadas.DataBind();
                lblError.Text = "No se encontraron jugadas";
            }

            if (colPreguntasJuego.Count != 0)
            {
                gvPreguntas.DataSource = colPreguntasJuego;
                gvPreguntas.DataBind();
            }
            else
            {
                gvPreguntas.DataSource = null;
                gvPreguntas.DataBind();
                lblError.Text = "No se encontraron Preguntas asociadas a este juego";
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}