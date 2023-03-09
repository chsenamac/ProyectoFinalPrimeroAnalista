using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;


namespace Persistencia
{
    public class PersistenciaPregunta
    {
        public static void Agregar(Pregunta unaPreg){
            
            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("AltaPregunta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoPregunta", unaPreg.CodigoPregunta);
            oComando.Parameters.AddWithValue("@puntaje", unaPreg.Puntaje);
            oComando.Parameters.AddWithValue("@textoPregunta", unaPreg.TextoPregunta);
            oComando.Parameters.AddWithValue("@respuestaCorrecta", unaPreg.RespuestaCorrecta);
            oComando.Parameters.AddWithValue("@respuestaUno", unaPreg.PreguntaUno);
            oComando.Parameters.AddWithValue("@respuestaDos", unaPreg.PreguntaDos);
            oComando.Parameters.AddWithValue("@respuestaTres", unaPreg.PreguntaTres);
            oComando.Parameters.AddWithValue("@codigoCategoriaPregunta", unaPreg.UnaCategoria.Codigo);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("Ya existe un pregunta con ese codigo.");
                else if (resultado == -2)
                    throw new Exception("No existe una categoria asociada");
                else if (resultado == -3)
                    throw new Exception("Error inesperado.");
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


        public static Pregunta Buscar(string vCodigo) {
            Pregunta oPregunta = null;

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("BuscarPregunta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoPregunta", vCodigo);

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        int puntaje = (int)oReader["puntaje"];
                        string texto = (string)oReader["textoPregunta"];
                        int respuestaCorrecta = (int)oReader["respuestaCorrecta"];
                        string respuestaUno = (string)oReader["respuestaUno"];
                        string respuestaDos = (string)oReader["respuestaDos"];
                        string respuestaTres = (string)oReader["respuestaDos"];
                        string codigoPregunta=(string)oReader["codigoCategoriaPregunta"];
                        Categoria oCategoria= PersistenciaCategoria.Buscar(codigoPregunta);
                        oPregunta = new Pregunta(vCodigo, puntaje, texto,respuestaCorrecta, respuestaUno
                            ,respuestaDos, respuestaTres, oCategoria);
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
            return oPregunta;
        }

        public static List<Pregunta> Listar(){
            List<Pregunta> colPreguntas = new List<Pregunta>();
            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("ListarPreguntas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        string codigoPregunta = oReader["codigoPregunta"].ToString();
                        int puntaje = Convert.ToInt32(oReader["puntaje"]);
                        string textoPregunta = oReader["textoPregunta"].ToString();
                        int respuestaCorrecta = Convert.ToInt32(oReader["respuestaCorrecta"]);
                        string preguntaUna = oReader["respuestaUno"].ToString();
                        string preguntaDos = oReader["respuestaDos"].ToString();
                        string preguntaTres = oReader["respuestaTres"].ToString();
                        string codigoCategoria = oReader["codigoCategoriaPregunta"].ToString();
                      
                        Categoria oCategoria = PersistenciaCategoria.Buscar(codigoCategoria);

                        Pregunta oPregunta = new Pregunta(codigoPregunta, puntaje, textoPregunta, respuestaCorrecta,
                            preguntaUna, preguntaDos, preguntaTres, oCategoria);
                        colPreguntas.Add(oPregunta);
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
            return colPreguntas;
        }

        public static List<Pregunta> ListarPreguntasDeUnJuego(long codigoJuego){

            List<Pregunta> colPreguntas = new List<Pregunta>();

            SqlConnection oConexion = new SqlConnection(Conexion.Cn);
            SqlCommand oComando = new SqlCommand("ListarPreguntasConJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        string codigoPregunta = oReader["codigoPregunta"].ToString();
                        Pregunta oPregunta =Buscar(codigoPregunta);
                        colPreguntas.Add(oPregunta);
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
            return colPreguntas;
        }


    }
}
