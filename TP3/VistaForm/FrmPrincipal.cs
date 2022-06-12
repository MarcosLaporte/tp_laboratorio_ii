using Entidades;
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

			try
			{
				this.clientes = Serializadora<List<Cliente>>.Leer("ListaDeClientes");
			}
			catch (ClienteInvalidoException)
			{
				MessageBox.Show("Hubo un error con la lista de clientes.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.clientes = new List<Cliente>();
			}

			this.productos = Serializadora<List<Producto>>.Leer("ListaDeProductos");
			this.ventas = Serializadora<List<Venta>>.Leer("ListaDeVentas");

			foreach (Cliente item in this.clientes)
			{
				this.lBxClientes.Items.Add(item.Dni);
			}
			foreach (Venta item in this.ventas)
			{
				this.lBxVentas.Items.Add(item.MostrarDatos(item));
			}
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
				Serializadora<List<Cliente>>.Escribir(this.clientes, "ListaDeClientes");
				Serializadora<List<Venta>>.Escribir(ventas, "ListaDeVentas");
			}
		}

		private void btnAgregarCliente_Click(object sender, EventArgs e)
		{
			this.formAgregarCliente = new FrmAgregarCliente();
			formAgregarCliente.ShowDialog();

			if (formAgregarCliente.DialogResult == DialogResult.OK)
			{
				Cliente cliente = formAgregarCliente.ClienteCreado;

				this.clientes += cliente;
				this.lBxClientes.Items.Add(cliente.Dni);
			}
		}

		private void lBxClientes_Click(object sender, EventArgs e)
		{
			object item = this.lBxClientes.SelectedItem;
			if (item is not null)
			{
				string stringDni = item.ToString();
				stringDni = stringDni.Trim(new char[] { ' ', '.', ',', '-' });
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
				stringDni = stringDni.Trim(new char[] { ' ', '.', ',', '-' });
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
						this.ventas.Add(nuevaVenta);
						this.lBxVentas.Items.Add(nuevaVenta.MostrarDatos(nuevaVenta));
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
				stringDni = stringDni.Trim(new char[] { ' ', '.', ',', '-' });
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
				stringDni = stringDni.Trim(new char[] { ' ', '.', ',', '-' });
				Cliente cliente = Cliente.GetClientePorDni(clientes, ulong.Parse(stringDni));

				if (cliente is not null)
				{
					DialogResult res = MessageBox.Show($"Desea eliminar la deuda de {cliente.Nombre} {cliente.Apellido}?",
								"Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					if (res == DialogResult.Yes)
					{
						cliente.Debe = 0;
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


		//MIS FUNCIONES
		public static string CortarStringEnCaracter(string cadena, char caracter)
		{
			string nuevaCadena = "";
			for (int i = 0; i < cadena.Length; i++)
			{
				if (cadena[i] == caracter)
				{
					break;
				}
				nuevaCadena += cadena[i];
			}

			return nuevaCadena;
		}
	}
}
