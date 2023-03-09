using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;


namespace Logica
{
    public class LogicaAdministrador
    {
        public static void Agregar(Administrador unAdmin) 
        {
            PersistenciaAdministrador.Agregar(unAdmin);
        }
        public static Administrador Buscar(string nombreUsuario)
        {
           return PersistenciaAdministrador.Buscar(nombreUsuario);
        }
        public static Administrador Login(string pUsu, string pPass) 
        {
            return PersistenciaAdministrador.Login(pUsu, pPass);
        }
    }
}
