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
        public static void Agregar(Juego unJuego) {

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("AltaJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@dificultad", unJuego.Dificultad);
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

        public static Juego Buscar(long codigo) {

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
                        string dificultad =(string) oReader["dificultad"];
                        string admin = (string)oReader["usuarioAdministradorJuego"];
                        Administrador unAdmin=PersistenciaAdministrador.Buscar(admin);
                        List<Pregunta> colPreguntas = PersistenciaPregunta.ListarPreguntasDeUnJuego(codigo);
                        oJuego = new Juego(codigo,fecha, dificultad, unAdmin, colPreguntas);
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
            List<Juego> coljuego = new List<Juego>();

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
                        long codigo = (long)oReader["codigoJuego"];
                        DateTime fecha = (DateTime)oReader["fechaCreacion"];
                        string dificultad = (string)oReader["dificultad"];
                        string admin = (string)oReader["usuarioAdministradorJuego"];
                        Administrador unAdmin = PersistenciaAdministrador.Buscar(admin);
                        List<Pregunta> colPreguntas = PersistenciaPregunta.ListarPreguntasDeUnJuego(codigo);
                        Juego oJuego = new Juego(codigo, fecha, dificultad, unAdmin, colPreguntas);
                        coljuego.Add(oJuego);
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
            return coljuego;   
        }

        public static List<Juego> ListarJuegosConPreguntas() {
            List<Juego> colJuegos = new List<Juego>();

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
                        long codigo = (long)oReader["codigoJuego"];
                        DateTime fecha = (DateTime)oReader["fechaCreacion"];
                        string dificultad = (string)oReader["dificultad"];
                        string admin = (string)oReader["usuarioAdministradorJuego"];
                        Administrador unAdmin = PersistenciaAdministrador.Buscar(admin);
                        List<Pregunta> colPreguntas = PersistenciaPregunta.ListarPreguntasDeUnJuego(codigo);
                        if (colPreguntas.Count > 0)
                        {
                            Juego oJuego = new Juego(codigo, fecha, dificultad, unAdmin, colPreguntas);
                            colJuegos.Add(oJuego);
                        }
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

        public static void AsociarPreguntaAUnJuego(Juego unJuego, Pregunta unaPregunta){

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
