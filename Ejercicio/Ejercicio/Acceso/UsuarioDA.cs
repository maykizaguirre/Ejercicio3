using Ejercicio.Datos;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Ejercicio.Acceso
{
    public class UsuarioDA 
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=ejercicio3; Uid = root; Pwd = Mayk123;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public Usuario UsuarioAcceso(string idUsuario, string clave)
        {
            Usuario usuario = null;
            try
            {
                string sql = "SELECT * FROM usuario WHERE Codigo = @IdUsuario AND Clave = @Clave;";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@Clave", clave);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {
                    usuario = new Usuario();
                    usuario.IdUsuario = reader[0].ToString();
                    usuario.Clave = reader[1].ToString();
                    usuario.Nombre = reader[2].ToString();
                    usuario.Perfil = reader[3].ToString();
                    usuario.Estado = Convert.ToBoolean(reader[4]);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {

            }
            return usuario;
        }

        public DataTable ListarUsuarios()
        {
            DataTable listaUsuarios = new DataTable();

            try
            {
                string sql = "SELECT * FROM usuario;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                listaUsuarios.Load(reader);
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return listaUsuarios;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            bool registro = false;
            try
            {
                string sql = "INSERT INTO usuario VALUES (@IdUsuario, @Clave, @Nombre, @Perfil, @Estado);";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Perfil", usuario.Perfil);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);

                cmd.ExecuteNonQuery();
                registro = true;

                conn.Close();
            }
            catch (Exception)
            {
            }
            return registro;
        }
    }


}
