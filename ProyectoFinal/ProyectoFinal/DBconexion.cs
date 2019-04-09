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
        public string sql; 
        public string cadena = "Server=DESKTOP-A0IQO3P\\SQLEXPRESS;Database=IGSS;user id=sa;Password=database";

        /*
        public DataTable Buscar(int id) //BUSCA AL USUARIO POR ID
        {
            DataTable Tabla = new DataTable();
            SqlDataAdapter adaptador;

            using(conexion = new SqlConnection(cadena))
            {
                conexion.Open();

                if(id < 300)
                    sql = "Select * From enfermera Where enfermeraID = @id";
                else
                    sql = "Select * From Doctor Where doctorID = @id";

                SqlParameter userID = new SqlParameter();
                userID.ParameterName = "@id";
                userID.Value = id;

                comand = new SqlCommand();
                comand.CommandType = CommandType.Text;
                comand.CommandText = sql;
                comand.Connection = conexion;
                comand.Parameters.Add(userID);
                comand.ExecuteNonQuery();

                adaptador = new SqlDataAdapter(comand);
                adaptador.Fill(Tabla);
            }

            return Tabla;
        }*/
        
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

        /*
        public void InsertarUsuario(string nickname, string clave)
        {
            //INSERTAR DATOS A LA TABLA USUARIO
            using (conexion = new SqlConnection(cadena))
            {
                conexion.Open();
                sql = "Insert into usuario (username, password) Values(@username, @password)";

                SqlParameter username = new SqlParameter();
                SqlParameter pass = new SqlParameter();

                username.Value = nickname;
                username.ParameterName = "@username";
                pass.Value = clave;
                pass.ParameterName = "@password";

                comand.Connection = conexion;
                comand.CommandType = System.Data.CommandType.Text;
                comand.CommandText = sql;
                comand.Parameters.Add(username);
                comand.Parameters.Add(pass);
                comand.ExecuteNonQuery();

            }//fin conexion
            
        }

        public void InsertarDoctor(int docID, int nodpi, string nombres, string apellidos, int cole, int celu, int tele, string mail, string dire, int espID)
        {
            using (conexion = new SqlConnection(cadena))
            {
                conexion.Open();
                sql = "Insert into Doctor (doctorID, dpi, nombres, apellidos, colegiado, celular, telefono, email, direccion, especialidadID) " +
                "Values(@docID, @dpi, @nombres, @apellidos, @cole, @cel, @tel, @email, @direc, @espID)";

                SqlParameter docid, dpi, nombre, apellido, colegiado, cel, tel, email, dir, espid;
                docid = dpi = nombre = apellido = colegiado = cel = tel = email = dir = espid = new SqlParameter();

                docid.Value = docID; docid.ParameterName = "@doctorID";
                dpi.Value = nodpi; dpi.ParameterName = "@dpi";
                nombre.Value = nombres; nombre.ParameterName = "@nombres";
                apellido.Value = apellidos; apellido.ParameterName = "@apellidos";
                colegiado.Value = cole; colegiado.ParameterName = "@cole";
                cel.Value = celu; cel.ParameterName = "@cel";
                tel.Value = tele; tel.ParameterName = "@tel";
                email.Value = mail; email.ParameterName = "@email";
                dir.Value = dire; dir.ParameterName = "@direc";
                espid.Value = espID; espid.ParameterName = "espID";

                comand.Connection = conexion;
                comand.CommandType = System.Data.CommandType.Text;
                comand.CommandText = sql;
                comand.Parameters.Add(docid);
                comand.Parameters.Add(dpi);
                comand.Parameters.Add(nombre);
                comand.Parameters.Add(apellido);
                comand.Parameters.Add(colegiado);
                comand.Parameters.Add(cel);
                comand.Parameters.Add(tel);
                comand.Parameters.Add(email);
                comand.Parameters.Add(dir);
                comand.Parameters.Add(espid);
                comand.ExecuteNonQuery();
            }
        }

    */
    }
}
