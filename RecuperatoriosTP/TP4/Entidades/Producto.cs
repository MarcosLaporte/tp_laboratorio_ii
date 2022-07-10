using Entidades.Productos;
using System.Text;
using System.Xml.Serialization;

namespace Entidades
{
	[XmlInclude(typeof(Higiene))]
	[XmlInclude(typeof(Medicamento))]
	[XmlInclude(typeof(Inyeccion))]
	public abstract class Producto
	{
		private int id;
		private string descripcion;
		private float precio;
		private ETipo tipo;

		public Producto()
		{

		}
		protected Producto(int id, string descripcion, float precio, ETipo tipo)
		{
			this.id = id;
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

		public string Datos()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"Tipo: {this.Tipo}.");
			sb.AppendLine($"Descripción: [{this.Id}] {this.Descripcion}.");
			sb.AppendLine($"Precio: {this.Precio:C}.");

			return sb.ToString();
		}
	}
}
