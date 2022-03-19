using Ejercicio.Acceso;
using Ejercicio.Datos;
using System;
using System.Windows.Forms;


namespace Ejercicio
{
    public partial class UsuariosVista : Form
    {
        

        public UsuariosVista()
        {
            InitializeComponent();
        }

        UsuarioDA usuarioDA = new UsuarioDA();
        string operacion = string.Empty;
        Usuario user = new Usuario();

        private void UsuariosVista_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            UsuariosDataGridView.DataSource = usuarioDA.ListarUsuarios();
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cerrando registro de usuarios");
            this.Close();
        }
    }
}
