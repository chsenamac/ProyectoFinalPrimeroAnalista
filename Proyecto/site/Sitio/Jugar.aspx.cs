using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using EntidadesCompartidas;
using Logica;

public partial class Jugar : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        lblErrorJuegos.Text = "";
        lblErrorPregunta.Text = "";
        if (!IsPostBack)
            CargoDatos();
    }

    private void CargoDatos()
    {
        try
        {
            Session["listaJuegos"] = LogicaJuego.ListarJuegosConPreguntas();
            Session["jugada"] = null;
            List<Juego> listaJuegos = (List<Juego>)Session["listaJuegos"];
            if (listaJuegos.Count > 0)
            {
                gvJuegos.DataSource = listaJuegos;
                gvJuegos.DataBind();
                rbPregunta1.Visible = false;
                rbPregunta2.Visible = false;
                rbPregunta3.Visible = false;
                btnEnviar.Visible = false;
            }
            else
            {
                lblErrorJuegos.ForeColor = Color.Red;
                lblErrorJuegos.Text = "No existen juegos cargados en el sistema.";
                rbPregunta1.Visible = false;
                rbPregunta2.Visible = false;
                rbPregunta3.Visible = false;
                btnEnviar.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblErrorJuegos.ForeColor = Color.Red;
            lblErrorJuegos.Text = ex.Message;
        }
    }


    protected void gvJuegos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Session["puntaje"] = 0;
            List<Juego> colJuegos = (List<Juego>)Session["listaJuegos"];
            Juego unjuego = colJuegos[gvJuegos.SelectedIndex];
            Session["juego"] = unjuego;
            Session["Preguntas"] = unjuego.Preguntas;
            Session["indice"] = 0;
            int indice = (int)Session["indice"];
            IngresarPreguntas(indice);
        }
        catch (Exception ex)
        {
            lblErrorJuegos.ForeColor = Color.Red;
            lblErrorJuegos.Text = ex.Message;
        }
    }
    private void IngresarPreguntas(int indice)
    {
        List<Pregunta> colPreguntas = (List<Pregunta>)Session["Preguntas"];
        try
        {
            if (colPreguntas.Count > indice)
            {
                lblTextoPregunta.Text = colPreguntas[indice].TextoPregunta;
                rbPregunta1.Text = colPreguntas[indice].PreguntaUno;
                rbPregunta2.Text = colPreguntas[indice].PreguntaDos;
                rbPregunta3.Text = colPreguntas[indice].PreguntaTres;
                rbPregunta1.Visible = true;
                rbPregunta2.Visible = true;
                rbPregunta3.Visible = true;
                btnEnviar.Visible = true;
            }
            else
            {
                Juego unjuego = (Juego)Session["juego"];
                Jugada unajugada = new Jugada(0, DateTime.Now, txtNombre.Text.Trim(), (int)Session["puntaje"], unjuego);
                LogicaJugada.Agregar(unajugada);
                lblErrorPregunta.ForeColor = Color.Blue;
                lblErrorPregunta.Text = "Gracias por participar el puntaje obtenido es de " + unajugada.Puntaje;
                rbPregunta1.Visible = false;
                rbPregunta2.Visible = false;
                rbPregunta3.Visible = false;
                btnEnviar.Visible = false;
                lblTextoPregunta.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblErrorPregunta.ForeColor = Color.Red;
            lblErrorPregunta.Text = ex.Message;
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNombre.Text.Trim() != "")
            {
                List<Pregunta> colpregunta = (List<Pregunta>)Session["Preguntas"];
                int indice = (int)Session["indice"];
                Pregunta unaPregunta = colpregunta[indice];
                if (rbPregunta1.Checked)
                {
                    if (unaPregunta.RespuestaCorrecta == 1)
                    {
                        int puntaje = (int)Session["puntaje"];
                        puntaje = puntaje + unaPregunta.Puntaje;
                        Session["puntaje"] = puntaje;
                        indice++;
                        Session["indice"] = indice;
                        IngresarPreguntas((int)Session["indice"]);
                    }
                    else
                    {
                        indice++;
                        Session["indice"] = indice;
                        IngresarPreguntas((int)Session["indice"]);
                    }
                }
                else if (rbPregunta2.Checked)
                {
                    if (unaPregunta.RespuestaCorrecta == 2)
                    {
                        int puntaje = (int)Session["puntaje"];
                        puntaje = puntaje + unaPregunta.Puntaje;
                        Session["puntaje"] = puntaje;
                        indice++;
                        Session["indice"] = indice;
                        IngresarPreguntas((int)Session["indice"]);
                    }
                    else
                    {
                        indice++;
                        Session["indice"] = indice;
                        IngresarPreguntas((int)Session["indice"]);
                    }
                }
                else if (rbPregunta3.Checked)
                {
                    if (unaPregunta.RespuestaCorrecta == 3)
                    {
                        int puntaje = (int)Session["puntaje"];
                        puntaje = puntaje + unaPregunta.Puntaje;
                        Session["puntaje"] = puntaje;
                        indice++;
                        Session["indice"] = indice;
                        IngresarPreguntas((int)Session["indice"]);
                    }
                    else
                    {
                        indice++;
                        Session["indice"] = indice;
                        IngresarPreguntas((int)Session["indice"]);
                    }
                }
                else
                {
                    lblErrorPregunta.ForeColor = Color.Red;
                    lblErrorPregunta.Text = "Para poder pasar a la siguiente pregunta debe seleccionar 1 respuesta.";
                }
            }
            else
            {
                lblErrorPregunta.ForeColor = Color.Red;
                lblErrorPregunta.Text = "Antes de enviar tu respuesta verifica que el nombre de usuario fue ingresado :)";
            }
        }
        catch (Exception ex)
        {
            lblErrorPregunta.ForeColor = Color.Red;
            lblErrorPregunta.Text = ex.Message;
        }
    }
}