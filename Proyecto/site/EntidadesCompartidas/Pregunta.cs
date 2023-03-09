using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Pregunta
    {
        private string codigoPregunta;
        private int puntaje;
        private string textoPregunta;
        private int respuestaCorrecta;
        private string preguntaUno;
        private string preguntaDos;
        private string preguntaTres;
        private Categoria unaCategoria;

        public string CodigoPregunta
        {

            get { return codigoPregunta; }
            set { codigoPregunta = value; }
        }

        public int Puntaje
        {
            get { return puntaje; }
            set
            {
                if (value >= 0 && value <= 10)
                    puntaje = value;
                else
                    throw new Exception("El puntaje debe estar entre 1 y 10");
            }
        }

        public string TextoPregunta
        {
            get { return textoPregunta; }
            set
            {
                if (value.Trim().Length <= 50)
                    textoPregunta = value;
                else
                    throw new Exception("Ingrese el texto pregunta");
            }
        }

        public int RespuestaCorrecta
        {
            get { return respuestaCorrecta; }
            set
            {
                if (value >= 1 && value <= 3)
                    respuestaCorrecta = value;
                else
                    throw new Exception("Ingrese un valor igual a 1, 2 o 3");
            }
        }

        public string PreguntaUno
        {
            get { return preguntaUno; }
            set
            {
                if (value.Trim().Length <= 50)
                    preguntaUno = value;
                else
                    throw new Exception("Ingrese el valor de la pregunta una. El mismo debe contener hasta 50 caracteres");
            }
        }

        public string PreguntaDos
        {
            get { return preguntaDos; }
            set
            {
                if (value.Trim().Length <= 50)
                    preguntaDos = value;
                else
                    throw new Exception("Ingrese el valor de la pregunta dos. El mismo debe contener hasta 50 caracteres");
            }
        }

        public string PreguntaTres
        {
            get { return preguntaTres; }
            set
            {
                if (value.Trim().Length <= 50)
                    preguntaTres = value;
                else
                    throw new Exception("Ingrese el valor de la pregunta tres. El mismo puede contener hasta 50 caracteres.");
            }
        }

        public Categoria UnaCategoria
        {

            get { return unaCategoria; }
            set
            {
                if (value != null)
                    unaCategoria = value;

                else
                    throw new Exception("Ingrese una categoria valida");
            }
        }

        public Pregunta(string vcodigo, int vpuntaje, string vtextopregunta, int vrespuestacorrecta,
            string vpregunta1, string vpregunta2, string vpregunta3, Categoria vunaCategoria)
        {
            CodigoPregunta = vcodigo;
            Puntaje = vpuntaje;
            TextoPregunta = vtextopregunta;
            RespuestaCorrecta = vrespuestacorrecta;
            PreguntaUno = vpregunta1;
            PreguntaDos = vpregunta2;
            PreguntaTres = vpregunta3;
            UnaCategoria = vunaCategoria;
        }
    }
}
