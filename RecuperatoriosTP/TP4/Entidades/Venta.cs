using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Excepciones;

namespace Entidades
{
    //public delegate Func<List<Cliente>, ulong, Cliente> DelegadoGetCliente();
    public class Venta
    {
        private float precio;
        private float senia;
        private ulong dniCliente;
        private List<Producto> productos;

		public Venta()
		{

		}
        public Venta(float precio, float senia, ulong dniCliente, List<Producto> productos) : this()
        {
            this.Precio = precio;
            this.Senia = senia;
            this.DniCliente = dniCliente;
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
        public ulong DniCliente
        {
            get { return this.dniCliente; }
			set { this.dniCliente = value; }
        }
        public List<Producto> Productos
		{
			get { return this.productos; }
			set { this.productos = value; }
		}
        #endregion

        public string MostrarDatos(Venta venta, Cliente cliente)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Precio total: {venta.precio:C}. ");
            if (cliente is not null)
                sb.AppendLine($"A nombre de {cliente.Apellido}, {cliente.Nombre}. ");
            else
                sb.AppendLine($"El cliente ya no se encuentra disponible. ");

            sb.AppendLine($"Pagó: {venta.senia:C}. ");
            sb.AppendLine($"\nProductos comprados: ");
			foreach (Producto item in venta.productos)
			{
                sb.AppendLine($"{item}");
			}

            return sb.ToString();
        }
    }
}
