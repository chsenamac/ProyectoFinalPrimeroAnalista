using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaAdministrador
    {
        public static void Agregar(Administrador unAdmin) {

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("AltaAdministrador", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nombreUsuario", unAdmin.NombreUsuario);
            oComando.Parameters.AddWithValue("@nombreCompleto", unAdmin.NombreCompleto);
            oComando.Parameters.AddWithValue("@passUsuario", unAdmin.Contraseña);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("Ya existe un Usuario con ese nombre.");
                else if (resultado == -2)
                    throw new Exception("ocurrio un error inesperado");
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
        public static Administrador Buscar( string nombreUsuario) 
        {

            Administrador unAdministrador = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("BuscarAdministrador", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
           

            try
            {
                oConexion.Open();
                SqlDataReader oLector = oComando.ExecuteReader();

                if (oLector.HasRows)
                {
                    if (oLector.Read())
                    {
                        unAdministrador = new Administrador(
                            (string)oLector["nombreUsuario"], (string)oLector["nombreCompleto"],
                            (string)oLector["passUsuario"]);
                    }
                }
                oLector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return unAdministrador;
        }
        public static Administrador Login(string pUsu, string pPass)
        {

            Administrador unAdministrador = null;
            string nombreUsuario;
            string nombreCompleto;
            string passUsuario;

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("LoginAdministrador", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nombreUsuario", pUsu);
            oComando.Parameters.AddWithValue("@passUsuario", pPass);

            try
            {
                oConexion.Open();
                SqlDataReader oLector = oComando.ExecuteReader();

                if (oLector.HasRows)
                {
                    if (oLector.Read())
                    {
                        nombreUsuario = oLector["nombreUsuario"].ToString();
                        nombreCompleto = oLector["nombreCompleto"].ToString();
                        passUsuario = oLector["passUsuario"].ToString();
                        unAdministrador = new Administrador(nombreUsuario, passUsuario, nombreCompleto);
                    }
                }
                oLector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return unAdministrador;
        }
     }
}
