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
        public static void Agregar(Juego unJuego) 
        {
            PersistenciaJuego.Agregar(unJuego);
        }
        public static Juego Buscar(long codigo) 
        {
            return PersistenciaJuego.Buscar(codigo);
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
