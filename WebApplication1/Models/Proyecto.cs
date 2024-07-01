using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace WebApplication_PNT1.Models
{
    public class Proyecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProyecto { get; set; }
        public required string Descripcion { get; set; }

        [Display(Name = "Ancho en cm")]
        public double Ancho { get; set; }

        [Display(Name = "Alto en cm")]
        public double Alto { get; set; }

        [Display(Name = "Grosor en cm")]
        public double Groso { get; set; }

        [Display(Name = "Cantidad de colores")]
        public int CantColores { get; set; } // VER FUNCIONALIDAD EN LA VISTA PARA AGREGAR COLORES CLIQUEANDO O MANDANDO VALOR NUMERICO


        [Display(Name = "Cantidad de unidades")]
        public int Cantidad { get; set; }

        public int? PedidoId { get; set; }
        public Pedido? Pedido { get; set; }


        [Display(Name = "Fecha")]
        public DateTime FechaPedido { get; set; }
        [EnumDataType(typeof(TipoProyecto))]
        public TipoProyecto Tipo { get; set; }


        [Display(Name = "Precio por unidad")]
        public double CostoUnitario { get; set; }

        [Display(Name = "Precio Total")]
        public double CostoTotal { get; set; }


        public double CalcularCosto()
        {

            double costoBase = Tipo.GetCostoBase();


            double tamaño = Ancho * Alto * Groso;


            double costoPorColor = 20.0;


            double costoUnitario = costoBase + (tamaño * 0.1) + (CantColores * costoPorColor);

            return costoUnitario;
        }

        public double CalcularCostoTotal()
        {
            double costoTotal = CalcularCosto() * Cantidad;

            return costoTotal;
        }


        public void SetCostos()
        {
            CostoUnitario = CalcularCosto();
            CostoTotal = CalcularCostoTotal();
        }


    }
}


