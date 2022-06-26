using Entidades;
using Entidades.ADOs;
using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VistaForm
{
	public partial class FrmPrincipal : Form
	{
		private List<Cliente> clientes;
		private List<Producto> productos;
		private List<Venta> ventas;
		private FrmAgregarCliente formAgregarCliente;
		private FrmAgregarPedido formAgregarPedido;

		public FrmPrincipal()
		{
			InitializeComponent();
		}
		private void FrmPrincipal_Load(object sender, EventArgs e)
		{
			this.lBxClientes.Items.Clear();
			this.lBxVentas.Items.Clear();

			//this.clientes = Serializadora<List<Cliente>>.Leer("ListaDeClientes");
			this.clientes = ClienteADO.ObtenerTodos();
			this.clientes.ForEach((item) => this.lBxClientes.Items.Add(item.Dni));

			//this.productos = Serializadora<List<Producto>>.Leer("ListaDeProductos");
			this.productos = ProductoADO.ObtenerTodos();

			this.ventas = Serializadora<List<Venta>>.Leer("ListaDeVentas");
			this.ventas.ForEach((item) => this.lBxVentas.Items.Add(item.MostrarDatos(item,
										Cliente.GetClientePorDni(this.clientes, item.DniCliente))));
		}
		private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult res = MessageBox.Show("Desea guardar los cambios realizados?",
						"Warning!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

			if (res == DialogResult.Cancel)
			{
				e.Cancel = true;
			}
			else if(res == DialogResult.Yes)
			{
				ClienteADO.Sobreescribir(this.clientes);
				Serializadora<List<Cliente>>.Escribir(this.clientes, "ListaDeClientes");
				Serializadora<List<Venta>>.Escribir(this.ventas, "ListaDeVentas");
			}
		}

		private void btnAgregarCliente_Click(object sender, EventArgs e)
		{
			this.formAgregarCliente = new FrmAgregarCliente();
			this.formAgregarCliente.ClientesExistentes = this.clientes;
			formAgregarCliente.ShowDialog();

			if (formAgregarCliente.DialogResult == DialogResult.OK)
			{
				Cliente nuevoCliente = formAgregarCliente.ClienteCreado;

				if(Cliente.AgregarCliente(ref this.clientes, nuevoCliente))
				{
					ClienteADO.Agregar(nuevoCliente);
					this.lBxClientes.Items.Add(nuevoCliente.Dni);
				}
			}
		}

		private void lBxClientes_Click(object sender, EventArgs e)
		{
			object item = this.lBxClientes.SelectedItem;
			if (item is not null)
			{
				string stringDni = item.ToString();
				Cliente clienteElegido = Cliente.GetClientePorDni(clientes, ulong.Parse(stringDni));

				if (clienteElegido is null)
				{
					this.rTBxClientes.Text = "El cliente ya no existe.";
					this.lBxClientes.Items.Remove(item);
				}
				else
				{
					this.rTBxClientes.Text = clienteElegido.ToString();
				}
			}
		}

		private void btnAgregarPedido_Click(object sender, EventArgs e)
		{
			object item = this.lBxClientes.SelectedItem;
			if (item is not null)
			{
				string stringDni = item.ToString();
				Cliente clienteElegido = Cliente.GetClientePorDni(clientes, ulong.Parse(stringDni));

				if (clienteElegido is not null)
				{
					this.formAgregarPedido = new FrmAgregarPedido();
					this.formAgregarPedido.ProductosDisponibles = productos;
					this.formAgregarPedido.Cliente = clienteElegido;
					clienteElegido.Debe += this.formAgregarPedido.Cliente.Debe;

					formAgregarPedido.ShowDialog();
					if (formAgregarPedido.DialogResult == DialogResult.OK)
					{
						Venta nuevaVenta = formAgregarPedido.Venta;
						Cliente clienteDeVenta = Cliente.GetClientePorDni(this.clientes, formAgregarPedido.Cliente.Dni);
						this.ventas.Add(nuevaVenta);
						this.lBxVentas.Items.Add(nuevaVenta.MostrarDatos(nuevaVenta, clienteDeVenta));
					}
				}
				else
				{
					MessageBox.Show("El cliente es nulo.");
				}
			}
			else
			{
				MessageBox.Show("Debe seleccionar a un cliente!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void lBxVentas_Click(object sender, EventArgs e)
		{
			object item = this.lBxVentas.SelectedItem;
			if (item is not null)
			{
				this.rTBxVentas.Text = item.ToString();
			}
		}

		private void btnBorrarCliente_Click(object sender, EventArgs e)
		{
			object item = this.lBxClientes.SelectedItem;
			if (item is not null)
			{
				string stringDni = item.ToString();
				Cliente cliente = Cliente.GetClientePorDni(clientes, ulong.Parse(stringDni));

				if (cliente is not null)
				{

					DialogResult res = MessageBox.Show($"Seguro que desea eliminar a {cliente.Nombre} {cliente.Apellido}?",
								"Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					if (res == DialogResult.Yes)
					{
						this.clientes.Remove(cliente);
						this.lBxClientes.Items.Remove(cliente.Dni);
					}
				}
				else
				{
					MessageBox.Show("El cliente es nulo.");
				}
			}
			else
			{
				MessageBox.Show("Debe seleccionar a un cliente!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnPagarPend_Click(object sender, EventArgs e)
		{
			object item = this.lBxClientes.SelectedItem;
			if (item is not null)
			{
				string stringDni = item.ToString();
				Cliente cliente = Cliente.GetClientePorDni(clientes, ulong.Parse(stringDni));

				if (cliente is not null)
				{
					DialogResult res = MessageBox.Show($"Desea eliminar la deuda de {cliente.Nombre} {cliente.Apellido}?",
								"Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					if (res == DialogResult.Yes)
					{
						cliente.Debe = 0;
						ClienteADO.PagarDeuda(cliente);
					}
				}
				else
				{
					MessageBox.Show("El cliente es nulo.");
				}
			}
			else
			{
				MessageBox.Show("Debe seleccionar a un cliente!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		/// <summary>
		/// Recorre una cadena y copia cada uno de sus caracteres 
		/// hasta que encuentra el mismo pasado por parámetro.
		/// </summary>
		/// <param name="cadena">La cadena a recorrer.</param>
		/// <param name="caracter">El caracter a encontrar.</param>
		/// <returns>La nueva cadena cortada.</returns>
		public static string CortarStringEnCaracter(string cadena, char caracter)
		{
			string nuevaCadena = "";
			for (int i = 0; i < cadena.Length; i++)
			{
				if (cadena[i] != caracter)
				{
					nuevaCadena += cadena[i];
				}
				else
				{
					break;
				}
			}

			return nuevaCadena;
		}
	}
}
