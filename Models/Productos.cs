namespace Asignacion2_Formulario.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }
            
        public string Producto { get; set; }

    }
    public class ContactViewModel
    {
        public Productos NuevoProducto { get; set; }
        public List<Productos> ProductosLista { get; set; } = new List<Productos>();
    }
}
