using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public static class ProductoExtension
	{
        public static string Datos(this Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Tipo: {p.Tipo}.");
            sb.AppendLine($"Descripción: [{p.Id}] {p.Descripcion}.");
            sb.AppendLine($"Precio: {p.Precio:C}.");

            return sb.ToString();
        }
    }
}
