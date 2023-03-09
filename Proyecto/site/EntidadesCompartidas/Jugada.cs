using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Jugada
    {
        private long codigoJugada;
        private DateTime fechaHora;
        private string jugador;
        private int puntaje;
        private Juego unJuego;

        public long CodigoJugada
        {
            get { return codigoJugada; }
            set { codigoJugada = value; }
        }
        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }
        public string Jugador
        {
            get { return jugador; }
            set
            {
                if (value.Trim().Length <= 20)
                    jugador = value;
                else
                    throw new Exception("Ingrese un nombre de Jugador. El jugador debe contener hasta 20 caracteres");
            }
        }
        public int Puntaje
        {
            get { return puntaje; }
            set
            {
                if (value > 0)
                    puntaje = value;
                else
                    throw new Exception("El puntaje debe tener un valor mayor a 0");
            }
        }
        public Juego UnJuego
        {
            get { return unJuego; }
            set
            {
                if (value != null)
                    unJuego = value;
                else
                    throw new Exception("Ingrese un Jugador.");
            }
        }

        public Jugada(long vcodigoJugada, DateTime vFechaHora, string vJugador,
            int vPuntaje, Juego vUnJuego)
        {


            CodigoJugada = vcodigoJugada;
            FechaHora = vFechaHora;
            Jugador = vJugador;
            Puntaje = vPuntaje;
            UnJuego = vUnJuego;
        }
    }
}
