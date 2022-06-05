using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Excepciones;

namespace Entidades
{
    public class Compra
    {
        private static int bancoIds;
        private int id;
        private float precio;
        private float senia;
        private Cliente cliente;
        private Farmacia<Cliente, Compra, Producto> productos;

        static Compra()
        {
            Compra.bancoIds = 1;
        }
        private Compra()
        {
            this.productos = new Farmacia<Cliente, Compra, Producto>();
        }
        public Compra(float precio, float senia, Cliente cliente) : this()
        {
            this.id = bancoIds;
            Compra.bancoIds++;
            this.Precio = precio;
            this.Senia = senia;
            this.Cliente = cliente;
        }

		#region Propiedades
		public int Id
        {
            get { return this.id; }
        }
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
        public Farmacia<Cliente, Compra, Producto> Productos
		{
			get { return this.productos; }
			set { this.productos = value; }
		}
        #endregion

        public string MostrarDatos(Compra compra)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id de compra: {compra.id}.");
            sb.AppendLine($"A nombre de:\n{compra.cliente}");
            sb.AppendLine($"Precio total: {compra.precio:C}.");
            sb.AppendLine($"Pagó: {compra.senia:C}.");

            return sb.ToString();
        }
        public string DatosResumidos(Compra compra)
        {
            return $"[{compra.id}]: de {compra.cliente.Apellido} por {compra.precio:C}.";
        }
    }
}
