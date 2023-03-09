using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    public class PersistenciaCategoria
    {
        public static void Agregar(Categoria unaCat){

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("AltaCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoCategoria", unaCat.Codigo);
            oComando.Parameters.AddWithValue("@nombre", unaCat.Nombre);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("Ya existe una categoria con ese codigo.");
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
        public static void Modificar(Categoria unaCat) 
        {

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("ModificarCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoCategoria", unaCat.Codigo);
            oComando.Parameters.AddWithValue("@nombre", unaCat.Nombre);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("No existe una categoria con ese codigo.");
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

        public static void Eliminar(Categoria unaCat)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("BajaCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oIsbn = new SqlParameter("@codigoCategoria", unaCat.Codigo);
            oIsbn.Direction = ParameterDirection.Input;

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oIsbn);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("No existe la categoria.");

                else if (resultado == -2)
                    throw new Exception("No se puede eliminar una Categoria con preguntas Asociadas.");

                else if (resultado == -3)
                    throw new Exception("Ocurrio un error inesperado");
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

        public static Categoria Buscar(string codigo) 
        {
            Categoria oCategoria = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("BuscarCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoCategoria", codigo);

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        string nombre = oReader["nombre"].ToString();
                        oCategoria = new Categoria(codigo,nombre);
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
            return oCategoria;
        }

        public static List<Categoria> Listar() {

            List<Categoria> colCategorias = new List<Categoria>();

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("ListarCategorias", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        string codigo = oReader["codigoCategoria"].ToString();
                        string nombre = oReader["nombre"].ToString();

                        Categoria oCategoria = new Categoria(codigo, nombre);
                        colCategorias.Add(oCategoria);
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
            return colCategorias;

        } 
    }
}
