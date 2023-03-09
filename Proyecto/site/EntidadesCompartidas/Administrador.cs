using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Administrador
    {
        private string nombreUsuario;
        private string contraseña;
        private string nombreCompleto;

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set
            {
               /* if (nombreUsuario == "")
                {
                    throw new Exception("Error. El nombre de usuario es un campo requerido, no puede estar vacio");
                } */ 
               
                if (value.Trim().Length>0 && value.Trim().Length<= 20)
                {
                    nombreUsuario = value;
                }
                else
                {
                    throw new Exception("Error. Ingrese un nombre de Usuario valido, puede contener hasta 20 caracteres.");
                }
            }
        }

        public string Contraseña
        {
            get { return contraseña; }
            set
            {
               /* if (contraseña == "")
                {
                    throw new Exception("Error. La contraseña es un campo requerido, no puede estar vacio");
                } */

                if (value.Trim().Length>0 && value.Trim().Length <= 20)
                {
                    contraseña = value;
                }
                else
                {
                    throw new Exception("Error. Ingrese una contraseña. Puede ingresar hasta 20 caracteres");
                }
            }

        }
        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set
            {

                if (value.Trim().Length > 0 && value.Trim().Length <= 50)
                {
                    nombreCompleto = value;
                }
                else
                    throw new Exception("Error. Ingrese un nombre completo.El nombre puede contener hasta 50 caracteres.");
            }

        }

        public Administrador(string vnombreUsuario, string vpass, string vNombreCompleto)
        {
            NombreUsuario = vnombreUsuario;
            Contraseña = vpass;
            NombreCompleto = vNombreCompleto;
        }
    }
}
