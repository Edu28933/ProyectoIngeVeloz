using CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAPA_PRESENTACION
{
    public partial class frm02Usuarios : Form
    {
        public frm02Usuarios()
        {
            InitializeComponent();
        }

        
            public void mtdMostrarUsuarios()
            {
                cd_02Usuarios cd_02Usuarios = new cd_02Usuarios();

                DataTable tbUsuarios = cd_02Usuarios.CP_mtdConsultarUsuarios();
                dgviewCrudUsuarios.DataSource = tbUsuarios;
            }




            public void mtdEliminarUsuarios()
            {
            try
            {
                cd_02Usuarios cd_02Usuarios = new cd_02Usuarios();


                string Usuario = dgviewCrudUsuarios.SelectedCells[0].Value.ToString();

                int registrosEliminados = cd_02Usuarios.CP_mtdEliminarUsuarios(Usuario);

                if (registrosEliminados > 0)
                {
                    MessageBox.Show("Registro Eliminado!!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontró código!!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al Eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            }


            public void mtdActualizarUsuarios()
            {
            try
            {
                cd_02Usuarios cd_02Usuarios = new cd_02Usuarios();

                int CodUsuario = int.Parse(txtcodUsuario.Text);

                string Usuario = txtUsuario.Text;
                string Contraseña = txtContraseña.Text;
                
                string Estado = cboxEstado.Text;

                int filasAfectadas = cd_02Usuarios.CD_mtdActualizarUsuario(CodUsuario, Usuario, Contraseña, Estado);

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Registro Actualizado!!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se actualizó registro!!!", "Advertencia!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al Actualizar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            }

            public void mtdBuscarDatosUsuarios()
            {
            try
            {
                cd_02Usuarios cd_02Usuarios = new cd_02Usuarios();
                string Usuario = txtBuscar.Text;
                DataTable dtBuscarUsuarios = cd_02Usuarios.CD_mtdBuscarUsuarios(Usuario);
                dgviewCrudUsuarios.DataSource = dtBuscarUsuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            }

            public void mtdAgregarUsuarios()
            {
            try
            {
                cd_02Usuarios cd_02Usuarios = new cd_02Usuarios();

                int CodUsuario = int.Parse(txtcodUsuario.Text);
                string Usuario = txtUsuario.Text;
                string Contraseña = txtContraseña.Text;
                string Estado = cboxEstado.Text;

                int registrosInsertados = cd_02Usuarios.CD_mtdInsertarUsuario(CodUsuario, Usuario, Contraseña, Estado);

                if (registrosInsertados > 0)
                {
                    MessageBox.Show("Registro Agregado!!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se agregó registro!!!", "Advertencia!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            }

        private void frm02Usuarios_Load(object sender, EventArgs e)
        {
            mtdMostrarUsuarios();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mtdBuscarDatosUsuarios();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            mtdEliminarUsuarios();
            mtdMostrarUsuarios();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
            cboxEstado.Text = "";
            mtdMostrarUsuarios();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            mtdAgregarUsuarios();
            mtdMostrarUsuarios();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            mtdActualizarUsuarios();
            mtdMostrarUsuarios();
        }

        private void dgviewCrudUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodUsuario.Text = dgviewCrudUsuarios.SelectedCells[0].Value.ToString();
            txtUsuario.Text = dgviewCrudUsuarios.SelectedCells[1].Value.ToString();
            txtContraseña.Text = dgviewCrudUsuarios.SelectedCells[2].Value.ToString();
            cboxEstado.Text = dgviewCrudUsuarios.SelectedCells[3].Value.ToString();
        }

        private void dgviewCrudUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
