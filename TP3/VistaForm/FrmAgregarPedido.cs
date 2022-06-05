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
		private Compra compraCreada;
		private Farmacia<Cliente, Compra, Producto> productosDisponibles;
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
		public Farmacia<Cliente, Compra, Producto> ProductosDisponibles
		{
			get { return this.productosDisponibles; }
			set { this.productosDisponibles = value; }
		}

		public Compra CompraCreada
        {
            get { return this.compraCreada; }
        }

		private void FrmAgregarPedido_Load(object sender, EventArgs e)
		{
			this.cBxTipo.Items.Add(ETipo.Higiene);
			this.cBxTipo.Items.Add(ETipo.Inyeccion);
			this.cBxTipo.Items.Add(ETipo.Medicamento);
		}

		private void cBxTipo_SelectedValueChanged(object sender, EventArgs e)
		{
			this.cBxProducto.Items.Clear();

			foreach (Producto item in productosDisponibles.ListaProductos)
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
					Producto producto = productosDisponibles.GetProductoPorId(productosDisponibles, id);
					if (producto is not null)
					{
						this.lblPrecioUnidad.Text = $"{producto.Precio:C}";
					}
				}
			}
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			object productoSeleccionado = this.cBxProducto.SelectedItem;
			if (productoSeleccionado is not null)
			{
				string stringId = FrmPrincipal.CortarStringEnCaracter(productoSeleccionado.ToString(), ':');
				if (int.TryParse(stringId, out int id))
				{
					Producto producto = productosDisponibles.GetProductoPorId(productosDisponibles, id);
					if (producto is not null)
					{
						this.precio += producto.Precio;
						//producto.stock--
						this.lblPrecioTotal.Text = $"{this.precio:C}";
						this.rTBxPedido.Text += producto.ToString();
						this.rTBxPedido.Text += "-----------------\n";
					}
					else
					{
						//throw new IdProductoNoExisteException();
					}
				}
				else
				{
					//throw new IdProductoInvalidoException();
				}
			}
			else
			{
				MessageBox.Show("Seleccione un producto.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnRePedido_Click(object sender, EventArgs e)
		{
			this.seniar = new FrmMontoSenia();
			seniar.ShowDialog();
			this.senia = seniar.SeniaCompra;

			if (this.senia == -1)
				this.senia = this.precio;

			if(seniar.DialogResult == DialogResult.OK)
			{
				this.cliente.Debe += this.precio - this.senia;
				this.compraCreada = new Compra(this.precio, this.senia, this.cliente);
				this.DialogResult = DialogResult.OK;
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
