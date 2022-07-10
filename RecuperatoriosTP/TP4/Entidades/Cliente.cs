using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
	public class Cliente
	{
		private string nombre;
		private string apellido;
		private string telefono;
		private ulong dni;
		private float debe;

		public Cliente()
		{

		}
		public Cliente(string nombre, string apellido, string telefono, ulong dni)
			: this(nombre, apellido, telefono, dni, 0)
		{

		}
		public Cliente(string nombre, string apellido, string telefono, ulong dni, float debe)
		{
			this.Nombre = nombre;
			this.Apellido = apellido;
			this.Telefono = telefono;
			this.Dni = dni;
			this.Debe = debe;
		}

		#region Propiedades
		public string Nombre
		{
			get { return this.nombre; }
			set
			{
				if (!String.IsNullOrWhiteSpace(value))
				{
					if (Cliente.CadenaEsValida(value))
					{
						this.nombre = value;
					}
					else
					{
						throw new NombreInvalidoException("El nombre debe ser sólo letras.");
					}
				}
				else
				{
					throw new NullReferenceException("El nombre no puede estar vacío.");
				}
			}
		}
		public string Apellido
		{
			get { return this.apellido; }
			set
			{
				if (!String.IsNullOrWhiteSpace(value))
				{
					if (Cliente.CadenaEsValida(value))
					{
						this.apellido = value;
					}
					else
					{
						throw new NombreInvalidoException("El apellido debe ser sólo letras.");
					}
				}
				else
				{
					throw new NullReferenceException("El apellido no puede estar vacío.");
				}
			}
		}
		public string Telefono
		{
			get { return this.telefono; }
			set
			{
				if (!String.IsNullOrEmpty(value))
				{

					if (long.TryParse(value, out _))
					{
						if (value.Length < 3 || value.Length > 15)
						{
							throw new TelefonoInvalidoException("El teléfono debe tener entre 3 y 15 dígitos numéricos.");
						}
						else
						{
							this.telefono = value;
						}
					}
					else
					{
						throw new TelefonoInvalidoException("El teléfono debe ser sólo números.");
					}
				}
				else
				{
					throw new NullReferenceException("El teléfono no puede estar vacío.");
				}
			}
		}
		public ulong Dni
		{
			get { return this.dni; }
			set
			{
				if (value.ToString().Length < 7 || value.ToString().Length > 9)
				{
					throw new DniInvalidoException("El DNI debe tener entre 7 y 9 números.");
				}
				else
				{
					this.dni = value;
				}
			}
		}
		public float Debe
		{
			get { return this.debe; }
			set
			{
				if (value < 0)
				{
					this.debe = 0;
					throw new DeudaInvalidaException("No puede existir una deuda negativa.");
				}
				else
				{
					this.debe = value;
				}
			}
		}
		#endregion

		private static string MostrarDatos(Cliente cliente)
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"-DNI: {cliente.dni}.");
			sb.AppendLine($"-Nombre: {cliente.nombre}.");
			sb.AppendLine($"-Apellido: {cliente.apellido}.");
			sb.AppendLine($"-Telefono: {cliente.telefono}.");
			sb.AppendLine($"-Debe: {cliente.debe:C}.");

			return sb.ToString();
		}

		public static bool CadenaEsValida(string cadena)
		{
			bool ret = true;
			foreach (char caracter in cadena)
			{
				if (!char.IsLetter(caracter) && caracter != ' ')
				{
					ret = false;
					break;
				}
			}

			return ret;
		}

		public static bool EscribirClientesEnTxt(List<Cliente> clientes)
		{
			bool ret = true;
			StringBuilder sb = new();
			sb.AppendLine($"Cantidad de clientes: {clientes.Count}");
			if (clientes.Count != 0)
			{
				sb.AppendLine("========================");
				clientes.ForEach((item) => sb.AppendLine(item + "\n-----------------\n"));
			}

			try
			{
				ArchivoTxt.Escribir(sb.ToString(), "ListaDeClientes");
			}
			catch (Exception)
			{
				ret = false;
			}

			return ret;
		}

		public static bool operator ==(Cliente a, Cliente b)
		{
			bool ret = false;
			if (a is not null && b is not null)
			{
				if (a.dni == b.dni)
				{
					ret = true;
				}
			}

			return ret;
		}
		public static bool operator !=(Cliente a, Cliente b)
		{
			return !(a == b);
		}
		public static bool operator ==(List<Cliente> a, Cliente b)
		{
			bool ret = false;
			if (a is not null && b is not null)
			{
				foreach (Cliente item in a)
				{
					if (item.Equals(b))
					{
						ret = true;
						break;
					}
				}
			}

			return ret;
		}
		public static bool operator !=(List<Cliente> a, Cliente b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			Cliente cliente = obj as Cliente;
			return cliente is not null && cliente == this;
		}
		public override string ToString()
		{
			return MostrarDatos(this);
		}

	}
}
