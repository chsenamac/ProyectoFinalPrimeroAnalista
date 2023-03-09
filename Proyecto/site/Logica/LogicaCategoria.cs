using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCategoria
    {
        public static void Agregar(Categoria unaCat)
        {
            PersistenciaCategoria.Agregar(unaCat);
        }
        public static void Modificar(Categoria unaCat)
        {
            PersistenciaCategoria.Modificar(unaCat);
        }
        public static void Eliminar(Categoria unaCat) 
        {
            PersistenciaCategoria.Eliminar(unaCat);
        }
        public static Categoria Buscar(string codigo) 
        {
            return PersistenciaCategoria.Buscar(codigo);
        }
        public static List<Categoria> Listar() 
        {
            return PersistenciaCategoria.Listar();
        }
    }
}
