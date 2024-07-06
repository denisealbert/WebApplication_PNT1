namespace WebApplication_PNT1.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; } // Cambiar a valor enum

        public List<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

        // Método para calcular el costo total de todos los proyectos en el pedido
        public double CalcularCostoTotal()
        {
            double costoTotal = 0.0;

            // Itera a través de cada proyecto en la lista y suma sus costos
            foreach (var proyecto in Proyectos)
            {
                costoTotal += proyecto.CalcularCosto(); // Asumiendo una cantidad de colores, cámbialo según sea necesario
            }

            return costoTotal;
        }

        public void agregarPedido(Proyecto proyecto)
        {
            Proyectos.Add(proyecto);
        }
    }

}