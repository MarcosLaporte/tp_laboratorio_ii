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
		private List<Venta> ventas;
		private FrmAgregarCliente formAgregarCliente;
		private FrmAgregarPedido formAgregarPedido;

		public FrmPrincipal()
		{
			InitializeComponent();
		}
		private void FrmPrincipal_Load(object sender, EventArgs e)
		{
			this.ventas = Serializadora<List<Venta>>.Leer("ListaDeVentas");

			this.lBxVentas.Items.Clear();
			if (this.ventas is not null)
			{
				this.ventas.ForEach((item) => this.lBxVentas.Items.Add(item.Datos()));
			}
			else
			{
				this.ventas = new();
			}

			this.RefrescarClientes();
		}

		private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult res = MessageBox.Show("Desea cerrar la aplicación?",
						"Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (res == DialogResult.No)
			{
				e.Cancel = true;
			}
			else
			{
				Serializadora<List<Cliente>>.Escribir((List<Cliente>)dtgvClientes.DataSource, "ListaDeClientes");
				Serializadora<List<Venta>>.Escribir(this.ventas, "ListaDeVentas");
			}
		}

		private void btnAgregarCliente_Click(object sender, EventArgs e)
		{
			this.formAgregarCliente = new FrmAgregarCliente();
			this.formAgregarCliente.ClientesExistentes = ClienteADO.ObtenerTodos();
			formAgregarCliente.ShowDialog();

			if (formAgregarCliente.DialogResult == DialogResult.OK)
			{
				ClienteADO.Agregar(formAgregarCliente.ClienteCreado);
				this.RefrescarClientes();
			}
		}

		private void btnAgregarPedido_Click(object sender, EventArgs e)
		{
			Cliente cliente = (Cliente)dtgvClientes.CurrentRow.DataBoundItem;

			if (cliente is not null)
			{
				this.formAgregarPedido = new FrmAgregarPedido();
				this.formAgregarPedido.ProductosDisponibles = ProductoADO.ObtenerTodos();
				this.formAgregarPedido.Cliente = cliente;

				formAgregarPedido.ShowDialog();
				if (formAgregarPedido.DialogResult == DialogResult.OK)
				{
					Venta nuevaVenta = formAgregarPedido.Venta;
					this.ventas.Add(nuevaVenta);
					this.lBxVentas.Items.Add(nuevaVenta.Datos());
					ClienteADO.CambiarDeuda(cliente, cliente.Debe);
					this.RefrescarClientes();
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
			Cliente cliente = (Cliente)dtgvClientes.CurrentRow.DataBoundItem;

			if (cliente is not null)
			{
				DialogResult res = MessageBox.Show($"Seguro que desea eliminar a {cliente.Nombre} {cliente.Apellido}?",
							"Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (res == DialogResult.Yes)
				{
					ClienteADO.Eliminar(cliente);
					this.RefrescarClientes();
				}
			}
			else
			{
				MessageBox.Show("Debe seleccionar a un cliente!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnPagarPend_Click(object sender, EventArgs e)
		{
			Cliente cliente = (Cliente)dtgvClientes.CurrentRow.DataBoundItem;

			if (cliente is not null)
			{
				DialogResult res = MessageBox.Show($"Desea eliminar la deuda de {cliente.Nombre} {cliente.Apellido}?",
							"Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (res == DialogResult.Yes)
				{
					cliente.Debe = 0;
					ClienteADO.CambiarDeuda(cliente, 0);
					this.RefrescarClientes();
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

		private void RefrescarClientes()
		{
			try
			{
				this.dtgvClientes.DataSource = ClienteADO.ObtenerTodos();
				this.dtgvClientes.Refresh();
				this.dtgvClientes.Update();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}
