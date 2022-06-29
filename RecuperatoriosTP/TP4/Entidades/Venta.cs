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

    }
}
