using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Juego
    {
        private long codigoJuego;
        private DateTime fechaCreado;
        private string dificultad;
        private Administrador unAdmin;
        //private List<Pregunta> preguntas;

        public long CodigoJuego
        {

            get { return codigoJuego; }
            set { codigoJuego = value; }
        }

        public DateTime FechaCreado
        {
            get { return fechaCreado; }
            set { fechaCreado = value; }
        }
        public string Dificultad
        {
            get { return dificultad; }
            set
            {
                if (value.Trim().ToUpper() == "DIFICIL" || value.Trim().ToUpper() == "MEDIO" || value.Trim().ToUpper() == "FACIL")
                {
                    dificultad = value;
                }

                else
                    throw new Exception("Error. Debe ingresar los valores Facil, Dificil o Media");
            }
        }
        public Administrador UnAdmin
        {
            get { return unAdmin; }
            set
            {
                if (value == null)
                    throw new Exception("Error. Debe ingresar un usuario administrador.");

                unAdmin = value;
            }
        }
        //public List<Pregunta> Preguntas
        //{
        //    get { return preguntas; }
        //    set
        //    {
        //        if (value == null)
        //            throw new Exception("Ingrese una lista de preguntas valida.");
        //        else
        //            preguntas = value;
        //    }
        //}

        public Juego(long vcodigo, DateTime vfechacreado, string vdificultad, Administrador vunAdmin)//,List<Pregunta> vPreguntas)
        {

            CodigoJuego = vcodigo;
            FechaCreado = vfechacreado;
            Dificultad = vdificultad;
            UnAdmin = vunAdmin;
            //Preguntas = vPreguntas;
        }
    }
}
