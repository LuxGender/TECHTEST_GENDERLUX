using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Back_datosUs.Models
{
    public class GestorDatosUsuario
    {
        public List<DatosUsuario> getDatosUsuario()
        {
            List<DatosUsuario> lista = new List<DatosUsuario>();
            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString(); //conexiona bse d datos

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand(); //nueva conexion
                cmd.CommandText = "DatosUsuario_All"; //creando referencia al nombre del procedure almacenado 
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read()) //para leer el data read
                { //variables para leer la columna de la tabla para poder psar a dtosUs
                    int id = dr.GetInt32(0); // configurando para leer posicion de id, primero lee nombre despues id
                    string Nombre = dr.GetString(1).Trim();
                    string Correo = dr.GetString(2).Trim();
                    string depto = dr.GetString(3).Trim();

                    //inicialinzando clase datosuS, cambio de datosUs a DatosUs
                    DatosUsuario Datos = new DatosUsuario(id, Nombre, Correo, depto);

                    lista.Add(Datos);
                }

                dr.Close();
                conn.Close();
            }

            return lista;
        }

        public bool DatosUsuarioAdd(DatosUsuario datos)

        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "DatosUsuario_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                //SqlParameter sqlParameter = cmd.Parameters.AddWithValue("@Nombre", DatosUs.Nombre);
                //cmd.Parameters.AddWithValue("@idUs", datos.idUs);
                cmd.Parameters.AddWithValue("@Nombre", datos.Nombre);
                cmd.Parameters.AddWithValue("@Correo", datos.Correo);
                cmd.Parameters.AddWithValue("@Depto", datos.Departamento);

                //para verificar si hubo algun error
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); //imprimir en consola el eror
                    res = false;
                    throw;
                }
                //si pasa el try catch limpia todos los parmetros
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;
            }

        }

        //para update
        public bool UpdateDatosUsuario(int id, DatosUsuario Datos)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "DatosUsuario_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Nombre", Datos.Nombre);
                cmd.Parameters.AddWithValue("@correo", Datos.Correo);
                cmd.Parameters.AddWithValue("@Depto", Datos.Departamento);

                //para verificar si hubo algun error
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); //imprimir en consola el eror
                    res = false;
                    throw;
                }
                //si pasa el try catch limpia todos los parmetros
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;
            }

        }
        //para eliminarç
        public bool DeleteDatosUsuario(int id)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "DatosUsuario_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                //para verificar si hubo algun error
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); //imprimir en consola el eror
                    res = false;
                    throw;
                }
                //si pasa el try catch limpia todos los parmetros
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;
            }

        }

    }
}
