using Entidades;
using Entidades.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaForm
{
	public partial class FrmAgregarPedido : Form
	{
		private Venta venta;
		private List<Producto> productosDisponibles;
		private List<Producto> carrito;
		private FrmMontoSenia seniar;

		private float precio = 0;
		private float senia = 0;
		private Cliente cliente;

		public FrmAgregarPedido()
		{
			InitializeComponent();
		}

		public Cliente Cliente
        {
            get { return this.cliente; }
            set { this.cliente = value; }
        }
		public List<Producto> ProductosDisponibles
		{
			get { return this.productosDisponibles; }
			set { this.productosDisponibles = value; }
		}
		public List<Producto> Carrito
		{
			get { return this.carrito; }
			set { this.carrito = value; }
		}
		public Venta Venta
		{
			get { return this.venta; }
		}

		public float Precio { get => this.precio; }
		public float Senia { get => this.senia; }

		private void FrmAgregarPedido_Load(object sender, EventArgs e)
		{
			this.carrito = new List<Producto>();

			this.cBxTipo.Items.Add(ETipo.Higiene);
			this.cBxTipo.Items.Add(ETipo.Inyeccion);
			this.cBxTipo.Items.Add(ETipo.Medicamento);
		}

		private void cBxTipo_SelectedValueChanged(object sender, EventArgs e)
		{
			this.cBxProducto.Items.Clear();

			foreach (Producto item in productosDisponibles)
			{
				if (this.cBxTipo.Text == "Medicamento" && item is Medicamento
					|| this.cBxTipo.Text == "Inyeccion" && item is Inyeccion
					|| this.cBxTipo.Text == "Higiene" && item is Higiene)
				{
					this.cBxProducto.Items.Add($"{item.Id}: {item.Descripcion}");
				}
			}
		}

		private void cBxProducto_SelectedValueChanged(object sender, EventArgs e)
		{
			object productoSeleccionado = this.cBxProducto.SelectedItem;
			if (productoSeleccionado is not null)
			{
				string stringId = FrmPrincipal.CortarStringEnCaracter(productoSeleccionado.ToString(), ':');
				if (int.TryParse(stringId, out int id))
				{
					Producto producto = Producto.GetProductoPorId(productosDisponibles, id);
					if (producto is not null)
					{
						this.lblPrecioUnidad.Text = $"{producto.Precio:C}";
					}
				}
			}
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			object item = this.cBxProducto.SelectedItem;
			if (item is not null)
			{
				string stringId = FrmPrincipal.CortarStringEnCaracter(item.ToString(), ':');
				if (int.TryParse(stringId, out int id))
				{
					Producto productoElegido = Producto.GetProductoPorId(productosDisponibles, id);
					if (productoElegido is not null)
					{
						this.carrito.Add(productoElegido);
						this.precio += productoElegido.Precio;
						this.lblPrecioTotal.Text = $"{this.precio:C}";
						this.rTBxPedido.Text += productoElegido.ToString();
						this.rTBxPedido.Text += "-----------------\n";
					}
				}
			}
			else
			{
				MessageBox.Show("Debe seleccionar un producto.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnRePedido_Click(object sender, EventArgs e)
		{
			if (this.carrito.Count != 0)
			{
				this.seniar = new FrmMontoSenia();
				this.seniar.PrecioVenta = this.precio;

				seniar.ShowDialog();
				this.senia = seniar.SeniaVenta;

				if (this.senia == -1)
					this.senia = this.precio;

				if (seniar.DialogResult == DialogResult.OK)
				{
					this.cliente.Debe += this.precio - this.senia;
					this.venta = new Venta(this.precio, this.senia, this.cliente.Dni, this.carrito);
					this.DialogResult = DialogResult.OK;
				}
			}
			else
			{
				MessageBox.Show("Debe agregar al menos un producto.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
			DialogResult res = MessageBox.Show("Seguro que desea cancelar el pedido?",
						"Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (res == DialogResult.Yes)
			{
				this.Close();
			}
		}
    }
}
