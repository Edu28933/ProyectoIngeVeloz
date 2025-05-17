using CAPADATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DATOS
{
    public class cd_02Usuarios
    {

        cd_Conexion cd_Conexion = new cd_Conexion();

        public DataTable MtMostrarUsuarios()
        {
            string QryMostrarUsuarios = "usp_usuarios_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarUsuarios, cd_Conexion.MtdAbrirConexion());
            DataTable dtMostrarUsuarios = new DataTable();
            adapter.Fill(dtMostrarUsuarios);
            cd_Conexion.MtdCerrarConexion();
            return dtMostrarUsuarios;
        }

    }
}
