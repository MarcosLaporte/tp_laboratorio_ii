using Entidades.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Higiene))]
    [XmlInclude(typeof(Medicamento))]
    [XmlInclude(typeof(Inyeccion))]
    public abstract class Producto
    {
        private static int bancoIds;
        private int id;
        private string descripcion;
        private float precio;
        private ETipo tipo;

		public Producto()
		{

		}
        static Producto()
        {
            bancoIds = 1;
        }
        protected Producto(string descripcion, float precio, ETipo tipo)
        {
            this.id = Producto.bancoIds;
            Producto.bancoIds++;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Tipo = tipo;
        }

        public int Id
        {
            get { return this.id; }
			set { this.id = value; }
        }
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }
        public float Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        public ETipo Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        protected virtual string Datos(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Tipo: {p.tipo}.");
            sb.AppendLine($"Descripción: [{p.id}] {p.descripcion}.");
            sb.AppendLine($"Precio: {p.precio:C}.");

            return sb.ToString();
        }

        /// <summary>
        /// Busca en la lista pasada por parámetro algún Producto que concuerde con el [id].
        /// </summary>
        /// <param name="lista">La lista donde buscar.</param>
        /// <param name="id">El id que buscar.</param>
        /// <returns>Retorna el Producto si lo encuentra; si no nulo.</returns>
        public static Producto GetProductoPorId(List<Producto> lista, int id)
        {
            Producto miProducto = null;
            foreach (Producto producto in lista)
            {
                if (producto.Id == id)
                {
                    miProducto = producto;
                    break;
                }
            }

            return miProducto;
        }
    }
}
