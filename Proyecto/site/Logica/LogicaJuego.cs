using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaJuego
    {
        public static void AgregarJuego(Juego unJuego) 
        {
            PersistenciaJuego.AgregarJuego(unJuego);
        }
        
        public static Juego BuscarJuego(int codigoJuego) 
        {
            return PersistenciaJuego.BuscarJuego(codigoJuego);
        }
        
        public static List<Juego> ListarTodosLosJuegos() 
        {
            return PersistenciaJuego.ListarTodosLosJuegos();
        }
        
        public static List<Juego> ListarJuegosConPreguntas() 
        {
            return PersistenciaJuego.ListarJuegosConPreguntas();
        }
        
        public static void AsociarPreguntaAUnJuego(Juego unJuego, Pregunta unaPregunta) 
        {
            PersistenciaJuego.AsociarPreguntaAUnJuego(unJuego, unaPregunta);
        }
        
        public static void DesacociarPreguntaDeUnJUego(Juego unJuego, Pregunta unaPregunta) 
        {
            PersistenciaJuego.DesacociarPreguntaDeUnJUego(unJuego,unaPregunta);
        }
    }
}
