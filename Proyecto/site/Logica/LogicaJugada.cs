using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaJugada
    {
        public static void Agregar(Jugada unaJug) 
        {
            PersistenciaJugada.Agregar(unaJug);
        }
        public static List<Jugada> Listar() 
        {
            return PersistenciaJugada.Listar();
        }
    }
}
