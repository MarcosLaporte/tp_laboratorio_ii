using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
	public class Venta
	{
		private int id;
		private float precio;
		private float senia;
		private ulong dniCliente;
		private List<Producto> productos;

		public Venta()
		{

		}
		public Venta(float precio, float senia, ulong dniCliente, List<Producto> productos)
		{
			this.Precio = precio;
			this.Senia = senia;
			this.DniCliente = dniCliente;
			this.Productos = productos;
		}
		public Venta(int id, float precio, float senia, ulong dniCliente, List<Producto> productos)
			: this(precio, senia, dniCliente, productos)
		{
			this.Id = id;
		}

		#region Propiedades
		public int Id
		{
			get { return this.id; }
			set { this.id = value; }
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

		public static bool EscribirVentasEnTxt(List<Venta> ventas)
		{
			bool ret = true;
			StringBuilder sb = new();
			sb.AppendLine($"Cantidad de ventas: {ventas.Count}");
			if (ventas.Count != 0)
			{
				sb.AppendLine("========================");
				ventas.ForEach((item) => sb.AppendLine(item.Datos() + "-----------------\n"));
			}

			try
			{
				ArchivoTxt.Escribir(sb.ToString(), "ListaDeVentas");
			}
			catch (Exception)
			{
				ret = false;
			}

			return ret;
		}

		public string Datos()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"Venta N°{this.Id}. ");
			sb.AppendLine($"A nombre del DNI: {this.DniCliente}. ");
			sb.AppendLine($"Precio total: {this.Precio:C}. ");
			sb.AppendLine($"Pagó: {this.Senia:C}. ");
			sb.AppendLine($"\nProductos comprados: ");
			foreach (Producto item in this.Productos)
			{
				sb.AppendLine($"{item}");
			}

			return sb.ToString();
		}
	}
}
