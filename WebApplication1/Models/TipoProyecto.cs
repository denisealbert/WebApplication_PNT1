using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApplication_PNT1.Models
{
    sealed class CostoBaseAttribute : Attribute
    {
        public double CostoBase { get; }
        public CostoBaseAttribute(double costoBase)
        {
            CostoBase = costoBase;
        }
    }
    public enum TipoProyecto
    {
        [CostoBase(100.0)]
        Figura3D,

        [CostoBase(50.0)]
        Iman,

        [CostoBase(75.0)]
        Otro
    }

    public static class TipoProyectoExtensions
    {
        public static double GetCostoBase(this TipoProyecto tipoProyecto)
        {
            FieldInfo fi = tipoProyecto.GetType().GetField(tipoProyecto.ToString());
            CostoBaseAttribute[] attributes = (CostoBaseAttribute[])fi.GetCustomAttributes(typeof(CostoBaseAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].CostoBase;
            }
            else
            {
                throw new InvalidOperationException("Costo base no definido para el tipo de proyecto.");
            }
        }
    }
}

