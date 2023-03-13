using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;


namespace Persistencia
{
    public class PersistenciaJuego
    {
        public static void AgregarJuego(Juego unJuego)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("AltaJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@dificultad", unJuego.Dificultad.ToUpper());
            oComando.Parameters.AddWithValue("@usuarioAdministradorJuego", unJuego.UnAdmin.NombreUsuario);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("Ocurrio un error inesperado.");

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                oConexion.Close();

            }
        }

        public static Juego BuscarJuego(int codigo)
        {

            Juego oJuego = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("BuscarJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoJuego", codigo);

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        DateTime fecha = (DateTime)oReader["fechaCreacion"];
                        string dificultad = (string)oReader["dificultad"];
                        string admin = (string)oReader["usuarioAdministradorJuego"];
                        Administrador unAdmin = PersistenciaAdministrador.Buscar(admin);
                        List<Pregunta> colPreguntas = PersistenciaPregunta.ListarPreguntasDeUnJuego(codigo);

                        oJuego = new Juego(codigo, fecha, dificultad, unAdmin, colPreguntas);
                    }
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return oJuego;
        }

        public static List<Juego> ListarTodosLosJuegos()
        {
            List<Juego> coljuegos = new List<Juego>();

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("ListarJuegos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int codigoJuego = Convert.ToInt32(oReader["codigoJuego"]);
                        DateTime fecha = Convert.ToDateTime(oReader["fechaCreacion"]);
                        string dificultad = oReader["dificultad"].ToString();
                        string admin = oReader["usuarioAdministradorJuego"].ToString();
                        Administrador unAdmin = PersistenciaAdministrador.Buscar(admin);
                        List<Pregunta> colPreguntas = PersistenciaPregunta.ListarPreguntasDeUnJuego(codigoJuego);
                        Juego oJuego = new Juego(codigoJuego, fecha, dificultad, unAdmin, colPreguntas);
                        coljuegos.Add(oJuego);
                    }
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            return coljuegos;
        }

        public static List<Juego> ListarJuegosConPreguntas()
        {
            List<Juego> colJuegos = new List<Juego>();

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("ListarJuegosConPregunta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int codigoJuego = Convert.ToInt32(oReader["codigoJuego"]);
                        colJuegos.Add(BuscarJuego(codigoJuego));
                    }
                }

                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            return colJuegos;
        }

        public static void AsociarPreguntaAUnJuego(Juego unJuego, Pregunta unaPregunta)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("AsociarPreguntaJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoJuego", unJuego.CodigoJuego);
            oComando.Parameters.AddWithValue("@codigoPregunta", unaPregunta.CodigoPregunta);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("No existe el codigo de juego");
                if (resultado == -2)
                    throw new Exception("No existe el codigo de pregunta");
                if (resultado == -2)
                    throw new Exception("Error inesperado");

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                oConexion.Close();

            }

        }

        public static void DesacociarPreguntaDeUnJUego(Juego unJuego, Pregunta unaPregunta)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("DesasociarPreguntaJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoJuego", unJuego.CodigoJuego);
            oComando.Parameters.AddWithValue("@codigoPregunta", unaPregunta.CodigoPregunta);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("No existe el codigo de juego");
                if (resultado == -2)
                    throw new Exception("No existe el codigo de pregunta");
                if (resultado == -2)
                    throw new Exception("Error inesperado");

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }
    }
}
