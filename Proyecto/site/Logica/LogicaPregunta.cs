﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPregunta
    {
        public static void Agregar(Pregunta unaPreg)
        {
            PersistenciaPregunta.Agregar(unaPreg);
        }

        public static Pregunta Buscar(string vCodigo)
        {
            return PersistenciaPregunta.Buscar(vCodigo);
        }

        public static List<Pregunta> Listar()
        {
            return PersistenciaPregunta.Listar();
        }

        public static List<Pregunta> ListarPreguntasDeUnJuego(int codigoJuego)
        {
            return PersistenciaPregunta.ListarPreguntasDeUnJuego(codigoJuego);
        }
        
        public static List<Pregunta> PreguntasNoAsociadasAJuego(Juego juego)
        {
            return PersistenciaPregunta.PreguntasNoAsociadasAJuego(juego);
        }

    }

}

