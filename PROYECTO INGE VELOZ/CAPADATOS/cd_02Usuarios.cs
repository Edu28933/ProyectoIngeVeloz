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
        private SqlConnection conn;

        public cd_02Usuarios()
        {
            conn = new SqlConnection("server=EDUARDO\\SQLEXPRESS; database=db_ProyectoBaseDatos; integrated security=true");
        }




        public DataTable CP_mtdConsultarUsuarios()
        {
            string queryConsultaUsuarios = "Select  * from tb_Usuarios";
            SqlDataAdapter adapter = new SqlDataAdapter(queryConsultaUsuarios, conn);
            DataTable tblUsuarios = new DataTable();
            adapter.Fill(tblUsuarios);
            return tblUsuarios;
        }

        public int CP_mtdEliminarUsuarios(string Usuario)
        {
            int cant;
            conn.Open();
            string qryEliminarUsuarios = "DELETE FROM tb_Usuairos WHERE Usuario=@Usuario";
            SqlCommand commandEliminarQry = new SqlCommand(qryEliminarUsuarios, conn);
            commandEliminarQry.Parameters.AddWithValue("@Usuario", Usuario);
            cant = commandEliminarQry.ExecuteNonQuery();
            return cant;
        }


        public int CD_mtdActualizarUsuario(int CodUsuario, string Usuario, string Contraseña, string Estado)
        {
            int filasAfectadas;
            conn.Open();
            string qryActualizaUsuarios = "UPDATE tb_Usuairos SET CodUsuario = @CodUsuario, Contraseña = @Contraseña, Estado = @Estado WHERE Usuario = @Usuario";
            SqlCommand commandActualizarQry = new SqlCommand(qryActualizaUsuarios, conn);
            commandActualizarQry.Parameters.AddWithValue("@CodUsuario", CodUsuario);
            commandActualizarQry.Parameters.AddWithValue("@Usuario", Usuario);
            commandActualizarQry.Parameters.AddWithValue("@Contraseña", Contraseña);
            commandActualizarQry.Parameters.AddWithValue("@Estado", Estado);
            filasAfectadas = commandActualizarQry.ExecuteNonQuery();
            conn.Close();
            return filasAfectadas;
        }

        public DataTable CD_mtdBuscarUsuarios(string Usuario)
        {
            conn.Open();
            string qryBuscarUsuarios = "SELECT * FROM tb_Usuarios WHERE Usuario LIKE @Usuario + '%'";
            SqlCommand commandBuscarQry = new SqlCommand(qryBuscarUsuarios, conn);
            commandBuscarQry.Parameters.AddWithValue("@Usuario", Usuario);

            SqlDataAdapter adapterBuscarUsuario = new SqlDataAdapter(commandBuscarQry);
            DataTable dtBuscarUsuario = new DataTable();
            adapterBuscarUsuario.Fill(dtBuscarUsuario);

            conn.Close();
            return dtBuscarUsuario;
        }

        public int CD_mtdInsertarUsuario(int CodUsuario, string Usuario, string Contraseña, string Estado)
        {

            int cant;
            conn.Open();
            string qryInsertaUsuarios = "INSERT INTO tb_Usuarios VALUES (@CodUsuario, @Usuario, @Contraseña, @Estado)";
            SqlCommand commandInsertarQry = new SqlCommand(qryInsertaUsuarios, conn);
            commandInsertarQry.Parameters.AddWithValue("@CodUsuario", CodUsuario);
            commandInsertarQry.Parameters.AddWithValue("@Usuario", Usuario);
            commandInsertarQry.Parameters.AddWithValue("@Contraseña", Contraseña);
            commandInsertarQry.Parameters.AddWithValue("@Estado", Estado);
            cant = commandInsertarQry.ExecuteNonQuery();
            return cant;
        }

    }
}
