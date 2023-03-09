using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    public class PersistenciaJugada
    {

        public static void Agregar(Jugada unaJug){

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("AlmacenarJugada", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@jugador", unaJug.Jugador);
            oComando.Parameters.AddWithValue("@codigoJuego", unaJug.UnJuego.CodigoJuego);
            oComando.Parameters.AddWithValue("@puntajeFinal", unaJug.Puntaje);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("No existe el Juego asociado.");
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

        public static List<Jugada> Listar(){
            List<Jugada> colJugadas = new List<Jugada>();
            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("ListarJugadas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        long codigo = (int)oReader["codigoJugada"];
                        DateTime fecha = (DateTime)oReader["fechaHoraJugada"];
                        string jugador = oReader["jugador"].ToString();
                        int puntaje = (int)oReader["respuestaCorrecta"];
                        long codigoJuego = (long)oReader["codigoJuego"];
                        Juego oJuego = PersistenciaJuego.Buscar(codigoJuego);

                        Jugada oJugada = new Jugada(codigo,fecha,jugador,puntaje,oJuego);
                        colJugadas.Add(oJugada);
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
            return colJugadas;
        }

    }
}
