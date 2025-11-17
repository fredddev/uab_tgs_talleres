namespace Talleres.Model.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        // contrasena almacenada como "iterations.saltBase64.hashBase64"
        public string Contrasena { get; set; } = string.Empty;
        public string Rol { get; set; } = "OPERADOR";
    }
}