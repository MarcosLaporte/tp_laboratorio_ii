using Entidades;
using Entidades.ADOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaForm
{
	public delegate void DelegadoAbrirArchivo(string nombreArchivo);
	public partial class FrmPrincipal : Form
	{
		public event DelegadoAbrirArchivo AbrirArchivoTxt;

		private FrmAgregarCliente formAgregarCliente;
		private FrmAgregarPedido formAgregarPedido;

		public FrmPrincipal()
		{
			InitializeComponent();
		}
		private void FrmPrincipal_Load(object sender, EventArgs e)
		{
			this.RefrescarClientes();
			this.RefrescarVentas();
			AbrirArchivoTxt += ManejadorAbrirArchivoTxt;
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
				Serializadora<List<Venta>>.Escribir((List<Venta>)dtgvVentas.DataSource, "ListaDeVentas");
				Venta.EscribirVentasEnTxt(LeerVentasDeBD());
				Cliente.EscribirClientesEnTxt(ClienteADO.ObtenerTodos());
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
					ClienteADO.CambiarDeuda(cliente, cliente.Debe);
					this.RefrescarClientes();

					VentaADO.Agregar(nuevaVenta);
					nuevaVenta.Productos.ForEach((producto) => CarritoADO.Agregar(VentaADO.ObtenerUltimaVenta(), producto.Id));
					this.RefrescarVentas();
				}
			}
			else
			{
				MessageBox.Show("Debe seleccionar a un cliente!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

		private void btnModificarCliente_Click(object sender, EventArgs e)
		{
			Cliente cliente = (Cliente)dtgvClientes.CurrentRow.DataBoundItem;

			this.formAgregarCliente = new FrmAgregarCliente(cliente);
			this.formAgregarCliente.ClientesExistentes = ClienteADO.ObtenerTodos();
			formAgregarCliente.ShowDialog();

			if (formAgregarCliente.DialogResult == DialogResult.OK)
			{
				ClienteADO.ModificarDatos(formAgregarCliente.ClienteCreado);
				this.RefrescarClientes();
			}
		}

		private void lblVentas_Click(object sender, EventArgs e)
		{
			DialogResult rta = MessageBox.Show("Desea abrir el archivo de ventas?", "Ventas.txt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (rta == DialogResult.Yes)
			{
				AbrirArchivoTxt?.Invoke("ListaDeVentas");
			}
		}

		private void lblClientes_Click(object sender, EventArgs e)
		{
			DialogResult rta = MessageBox.Show("Desea abrir el archivo de clientes?", "Clientes.txt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (rta == DialogResult.Yes)
			{
				AbrirArchivoTxt?.Invoke("ListaDeClientes");
			}
		}

		//MIS MÉTODOS
		private void RefrescarClientes()
		{
			try
			{
				this.dtgvClientes.DataSource = ClienteADO.ObtenerTodos();
				this.dtgvClientes.Refresh();
				this.dtgvClientes.Update();
				Cliente.EscribirClientesEnTxt(ClienteADO.ObtenerTodos());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void RefrescarVentas()
		{
			try
			{
				this.dtgvVentas.DataSource = LeerVentasDeBD();
				this.dtgvVentas.Refresh();
				this.dtgvVentas.Update();
				Venta.EscribirVentasEnTxt(LeerVentasDeBD());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private static List<Venta> LeerVentasDeBD()
		{
			List<Venta> ventas = VentaADO.ObtenerTodas();
			foreach (Venta item in ventas)
			{
				List<Producto> productos = CarritoADO.ObtenerProductosDeVenta(item.Id);
				item.Productos = productos;
			}

			return ventas;
		}

		private void ManejadorAbrirArchivoTxt(string nombreArchivo)
		{
			Task t = Task.Run(() =>
			{
				string archivo = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{nombreArchivo}.txt";
				Process proceso = new Process();
				proceso.StartInfo = new ProcessStartInfo()
				{
					UseShellExecute = true,
					FileName = archivo
				};

				proceso.Start();
			});
		}
	}
}
