using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Excepciones;

namespace Entidades
{
    public class Venta
    {
        private float precio;
        private float senia;
        private Cliente cliente;
        private List<Producto> productos;

		public Venta()
		{

		}
        public Venta(float precio, float senia, Cliente cliente, List<Producto> productos) : this()
        {
            this.Precio = precio;
            this.Senia = senia;
            this.Cliente = cliente;
            this.Productos = productos;
        }

		#region Propiedades
        public float Precio
		{
			get { return this.precio; }
			set { this.precio = value; }
		}
        public float Senia
		{
			get { return this.senia; }
			set { this.senia = value; }
		}
        public Cliente Cliente
        {
            get { return this.cliente; }
			set { this.cliente = value; }
        }
        public List<Producto> Productos
		{
			get { return this.productos; }
			set { this.productos = value; }
		}
        #endregion

        public static string MostrarDatos(Venta venta)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"A nombre de {venta.cliente.Apellido}, {venta.cliente.Nombre}.");
            sb.AppendLine($"Precio total: {venta.precio:C}.");
            sb.AppendLine($"Pagó: {venta.senia:C}.");
            sb.AppendLine($"\nProductos comprados:");
			foreach (Producto item in venta.productos)
			{
                sb.AppendLine($"{item}");
			}

            return sb.ToString();
        }
    }
}
