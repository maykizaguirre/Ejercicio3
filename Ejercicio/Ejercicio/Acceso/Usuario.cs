namespace Ejercicio.Datos
{
    public class Usuario
    {
        public string IdUsuario { get; set; }
        public string Clave { get; set; }

        public string Nombre { get; set; }

        public string Perfil { get; set; }

        public bool Estado { get; set; }

        public Usuario()
        {
        }

        public Usuario(string idUsuario, string clave, string nombre, string perfil, bool estado)
        {
            IdUsuario=idUsuario;
            Clave=clave;
            Nombre=nombre;
            Perfil=perfil;
            Estado=estado;
        }
    }
}
