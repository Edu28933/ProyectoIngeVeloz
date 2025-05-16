using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_SEGURIDAD
{
    public class cs_00Login
    {
        public static class UsuarioAutenticacion
        {
            public static string mtdValidacion(string usuario, string Contraseña)
            {
                string Usuario = null;
                string conexionString = "server=EDUARDO\\SQLEXPRESS; database=db_ProyectoBaseDatos; integrated security=true";

                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    string query = "SELECT Usuario FROM tb_Usuarios WHERE Usuario=@Usuario AND Contraseña=@Contraseña AND Estado='Activo'";
                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.Parameters.AddWithValue("@Contraseña", Contraseña);

                        conexion.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            Usuario = reader["Usuario"].ToString();
                        }
                    }
                }

                return Usuario;
            }
        }
    }
}
