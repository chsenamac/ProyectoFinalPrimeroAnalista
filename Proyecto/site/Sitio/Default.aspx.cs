using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Drawing;
using Logica;
using EntidadesCompartidas;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Jugada> colJugadas = LogicaJugada.Listar();

        Session["Admin"] = null;

        if (colJugadas.Count == 0)
        {
            throw new Exception("No se encontraron jugadas");
        }
        else
        {
            List<object> colJugadasDefault = new List<object>();

            foreach (Jugada jugada in colJugadas)
            {
                //var es para declarar una variable de tipo implicito (o sea que queda a criterio del compilador el tipo de esa variable)
                // por ejemplo var x = 10, lo tomaria como int, en el caso de jugadaDefault lo toma como string

                var jugadaDefault = new
                {
                    FechaHora = jugada.FechaHora.ToString(),
                    Jugador = jugada.Jugador.ToString(),
                    Puntaje = jugada.Puntaje.ToString()
                };

                colJugadasDefault.Add(jugadaDefault);
            }

            gvJugadas.DataSource = colJugadasDefault;
            gvJugadas.DataBind();
        }

    }

    protected void imgButtonJugar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Jugar.aspx");
    }
}