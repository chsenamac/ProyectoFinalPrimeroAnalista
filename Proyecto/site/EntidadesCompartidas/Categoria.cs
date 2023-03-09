using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EntidadesCompartidas
{
    public class Categoria
    {

        private string nombre;
        private string codigo;

        private string expRegular = "^[a-zA-Z]{4}$";

        public string Nombre
        {

            get { return nombre; }
            set
            {
                if (value.Trim().Length>0 && value.Trim().Length <= 20)
                {
                    nombre = value;
                }
                else
                    throw new Exception("Error. Ingrese un nombre de categoria. La categoria puede contener hasta 20 caracteres.");

            }
        }

        public string Codigo
        {

            get { return codigo; }
            set
            {
                if (!Regex.IsMatch(value, expRegular))
                {
                    throw new Exception("Error. El codigo de categoria debe contener unicamente 4 letras.");
                }
                else
                    codigo = value;
            }
        }

        public virtual string rblMostrarCategorias
        {
            get { return nombre; }
        }


        public Categoria(string vcodigo, string vnombre)
        {
            Nombre = vnombre;
            Codigo = vcodigo;
        }
    }
}
