using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public static class Extensiones
	{
        public static string Datos(this Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Tipo: {p.Tipo}.");
            sb.AppendLine($"Descripción: [{p.Id}] {p.Descripcion}.");
            sb.AppendLine($"Precio: {p.Precio:C}.");

            return sb.ToString();
        }

        public static string Datos(this Venta v)
		{
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"A nombre del DNI: {v.DniCliente}. ");
            sb.AppendLine($"Precio total: {v.Precio:C}. ");
            sb.AppendLine($"Pagó: {v.Senia:C}. ");
            sb.AppendLine($"\nProductos comprados: ");
            foreach (Producto item in v.Productos)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString();
        }
    }
}
