using Ejercicio.Acceso;
using Ejercicio.Datos;
using System;
using System.Windows.Forms;

namespace Ejercicio
{
    public partial class UsuarioAcceso : Form
    {
        public UsuarioAcceso()
        {
            InitializeComponent();
        }

        

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            UsuarioDA usuarioDA = new UsuarioDA();
            Usuario usuario = new Usuario();

            usuario = usuarioDA.UsuarioAcceso(UsuarioTextBox.Text, ClaveTextBox.Text);

            if (usuario == null)
            {
                MessageBox.Show("Datos incorrectos, ingresar un usuario existente");
                return;
            }
            else if (!usuario.Estado)
            {
                MessageBox.Show("Usuario inactivo");
                return;
            }

            UsuariosVista usuariosVista = new UsuariosVista();
            usuariosVista.Show();
            this.Hide();

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
