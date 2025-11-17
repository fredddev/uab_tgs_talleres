namespace Talleres.Model.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Contacto { get; set; }
        public string? Telefono { get; set; }

        public override string ToString() => Nombre;
    }
}