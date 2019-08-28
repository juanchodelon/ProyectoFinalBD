using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace ProyectoFinal
{
    class DBconexion
    {
        public SqlConnection connect;
        public SqlCommand comand = new SqlCommand();
        public string cadena = "Server=172.17.184.114;Database=IGSS;user id=sa;Password=database";
        
        public DataTable Consulta(string _sql, ArrayList Nombre, ArrayList Valor)
        {
            SqlDataAdapter adaptador;
            SqlParameter parametro;
            DataTable Tabla = new DataTable();
            using (connect = new SqlConnection(cadena))
            {
                connect.Open();
                comand.CommandType = CommandType.Text;
                comand.CommandText = _sql;
                comand.Connection = connect;
                if (Nombre != null)
                    for (short x = 0; x < Nombre.Count; x++)
                    {
                        parametro = new SqlParameter();
                        parametro.ParameterName = Nombre[x].ToString();
                        parametro.Value = Valor[x].ToString();
                        comand.Parameters.Add(parametro);
                    }
                adaptador = new SqlDataAdapter(comand);
                adaptador.Fill(Tabla);
                comand.Parameters.Clear();
            }//fin using
            return Tabla;
        }

        public string crud(string _sql, ArrayList Nombre, ArrayList Valor)
        {
            SqlParameter parametro;
            string resultado = "";
            try
            {
                using (connect = new SqlConnection(cadena))
                {
                    connect.Open();
                    comand.CommandType = CommandType.Text;
                    comand.CommandText = _sql;
                    comand.Connection = connect;
                    if (Nombre != null)
                        for (short x = 0; x < Nombre.Count; x++)
                        {
                            parametro = new SqlParameter();
                            parametro.ParameterName = Nombre[x].ToString();
                            parametro.Value = Valor[x].ToString();
                            comand.Parameters.Add(parametro);
                        }
                    comand.ExecuteNonQuery();
                    resultado = "operacion exitosa";
                    comand.Parameters.Clear();
                }
            }
            catch (Exception error)
            {
                resultado = "Error: " + error.Message;
            }
            return resultado;
        }//fin crud
    }
}
