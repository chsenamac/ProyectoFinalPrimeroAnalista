using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using System.Drawing;
using Logica;

public partial class ManejoDePreguntasDeUnJuego : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
        lblErrorAgregarPreguntas.Text = "";
        if (!IsPostBack)
            CargoDatos();
    }

    public void CargoDatos() 
    {
        try
        {
            Session["listaJuegos"] = LogicaJuego.ListarTodosLosJuegos();
            List<Juego> listaJuegos = (List<Juego>)Session["listaJuegos"];

            if (listaJuegos.Count > 0)
            {
                ddlJuego.DataSource = listaJuegos;
                ddlJuego.DataTextField = "CodigoJuego";
                ddlJuego.DataValueField = "CodigoJuego";
                ddlJuego.DataBind();
               
                Juego unJuego=listaJuegos[ddlJuego.SelectedIndex];
                Session["Juego"] = unJuego;
                List<Pregunta> preguntasAsociadas = unJuego.Preguntas;
                Session["PreguntasDeUnJuegoJuegos"] = preguntasAsociadas;
                
                List<Pregunta> preguntasNoAsignadasAUnJuego = LogicaPregunta.PreguntasNoAsociadasAJuego(unJuego);
                Session["PreguntasNoAsociadasAJuego"] = preguntasNoAsignadasAUnJuego;
                if (preguntasAsociadas.Count > 0)
                {
                    
                    gvPreguntas.DataSource = preguntasAsociadas;
                    gvPreguntas.DataBind();
                }
                else
                {
                    gvPreguntas.DataSource = null;
                    gvPreguntas.DataBind();
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Este juego no tiene preguntas asociadas";
                    
                }
                if (preguntasNoAsignadasAUnJuego.Count > 0)
                {
                   
                    gvPreguntasNoVinculadas.DataSource = preguntasNoAsignadasAUnJuego;
                    gvPreguntasNoVinculadas.DataBind();
                }
                else 
                {
                    gvPreguntasNoVinculadas.DataSource = null;
                    gvPreguntasNoVinculadas.DataBind();
                    lblErrorAgregarPreguntas.ForeColor = Color.Red;
                    lblErrorAgregarPreguntas.Text = "No se muestran preguntas para agregar porque este juego tiene todas las preguntas asociadas";
                    
                }
                
            }
            else 
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "No existen Juegos.";
                ddlJuego.Enabled = false;
                
            }
            
        }
        catch(Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }


    protected void ddlJuego_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<Juego> listajuegos = (List<Juego>)Session["listaJuegos"];
            Juego unJuego = listajuegos[ddlJuego.SelectedIndex];
            Session["Juego"] = unJuego;
            List<Pregunta> preguntasAsociadas = unJuego.Preguntas;
            Session["PreguntasDeUnJuegoJuegos"] = preguntasAsociadas;
            List<Pregunta> preguntasNoAsignadasAUnJuego = LogicaPregunta.PreguntasNoAsociadasAJuego(unJuego);
            Session["PreguntasNoAsociadasAJuego"] = preguntasNoAsignadasAUnJuego;
            if (preguntasAsociadas.Count > 0)
            {

                gvPreguntas.DataSource = preguntasAsociadas;
                gvPreguntas.DataBind();
                Session["PreguntasDeUnJuegoJuegos"] = preguntasAsociadas;
            }
            else
            {

                gvPreguntas.DataSource = null;
                gvPreguntas.DataBind();
                lblError.ForeColor = Color.Red;
                lblError.Text = "Este juego no tiene preguntas asociadas";
            }
            if (preguntasNoAsignadasAUnJuego.Count > 0)
            {

                gvPreguntasNoVinculadas.DataSource = preguntasNoAsignadasAUnJuego;
                gvPreguntasNoVinculadas.DataBind();
                Session["PreguntasNoAsociadasAJuego"] = preguntasNoAsignadasAUnJuego;
            }
            else
            {
                gvPreguntasNoVinculadas.DataSource = null;
                gvPreguntasNoVinculadas.DataBind();
                lblErrorAgregarPreguntas.ForeColor = Color.Red;
                lblErrorAgregarPreguntas.Text = "No se muestran preguntas para agregar porque este juego tiene todas las preguntas asociadas";

            }

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }


    protected void gvPreguntas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<Pregunta> colPreguntasVinculadas = (List<Pregunta>)Session["PreguntasDeUnJuegoJuegos"];
            int indice = gvPreguntas.SelectedIndex;
            Pregunta unaPregunta = colPreguntasVinculadas[indice];
           
            List<Pregunta> colpreguntasDesvinculadas = (List<Pregunta>)Session["PreguntasNoAsociadasAJuego"];
            colpreguntasDesvinculadas.Add(unaPregunta);
            
            Juego juego = (Juego)Session["Juego"];
            LogicaJuego.DesacociarPreguntaDeUnJUego(juego,unaPregunta);
            
            lblError.ForeColor = Color.Green;
            lblError.Text = "Usted desvinculo la pregunta con texto : " + unaPregunta.TextoPregunta;
            lblErrorAgregarPreguntas.Text = "";

            colPreguntasVinculadas.Remove(unaPregunta);
            Session["PreguntasDeUnJuegoJuegos"]=colPreguntasVinculadas;
            gvPreguntas.DataSource = colPreguntasVinculadas;
            gvPreguntas.DataBind();
            gvPreguntasNoVinculadas.DataSource = colpreguntasDesvinculadas;
            gvPreguntasNoVinculadas.DataBind();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    protected void gvPreguntasNoVinculadas_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            List<Pregunta> colPreguntasVinculadas = (List<Pregunta>)Session["PreguntasDeUnJuegoJuegos"];
            List<Pregunta> colpreguntasDesvinculadas = (List<Pregunta>)Session["PreguntasNoAsociadasAJuego"];

            int indice = gvPreguntasNoVinculadas.SelectedIndex;
            Pregunta unaPregunta = colpreguntasDesvinculadas[indice];
            
            Juego juego = (Juego)Session["Juego"];
            LogicaJuego.AsociarPreguntaAUnJuego(juego, unaPregunta);

            lblErrorAgregarPreguntas.ForeColor = Color.Green;
            lblErrorAgregarPreguntas.Text = "Usted vinculo la pregunta con texto : " + unaPregunta.TextoPregunta;
            lblError.Text = "";

            colpreguntasDesvinculadas.Remove(unaPregunta);
            gvPreguntasNoVinculadas.DataSource = colpreguntasDesvinculadas;
            gvPreguntasNoVinculadas.DataBind();

            colPreguntasVinculadas.Add(unaPregunta);
            gvPreguntas.DataSource = colPreguntasVinculadas;
            gvPreguntas.DataBind();
            Session["PreguntasDeUnJuegoJuegos"] = colPreguntasVinculadas;

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}