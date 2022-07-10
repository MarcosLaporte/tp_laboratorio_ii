using Entidades;
using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VistaForm
{
	public partial class FrmAgregarCliente : Form
	{
		private Cliente clienteCreado;
		private List<Cliente> clientesExistentes;
		public FrmAgregarCliente()
		{
			InitializeComponent();
		}
		public FrmAgregarCliente(Cliente clienteAModificar) : this()
		{
			this.tBxNombre.Text = clienteAModificar.Nombre;
			this.tBxApellido.Text = clienteAModificar.Apellido;
			this.tBxTelefono.Text = clienteAModificar.Telefono;
			this.tBxDni.Text = clienteAModificar.Dni.ToString();
			this.tBxDni.ReadOnly = true;
			this.btnAgregar.Text = "Modificar";
		}

		public Cliente ClienteCreado
		{
			get { return this.clienteCreado; }
			set { this.clienteCreado = value; }
		}
		public List<Cliente> ClientesExistentes
		{
			set { this.clientesExistentes = value; }
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			string nombre = this.tBxNombre.Text;
			string apellido = this.tBxApellido.Text;
			string telefono = this.tBxTelefono.Text;

			try
			{
				ulong dni = ulong.Parse(this.tBxDni.Text);
				Cliente cliente = new Cliente(nombre, apellido, telefono, dni);
				if (this.btnAgregar.Text == "Modificar" || clientesExistentes != cliente)
				{
					this.ClienteCreado = cliente;
					this.DialogResult = DialogResult.OK;
				}
				else
				{
					MessageBox.Show("Este DNI ya existe! Reingrese.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (NullReferenceException)
			{
				MessageBox.Show("Ningún campo puede quedar vacío. Reingrese.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (ClienteInvalidoException ex)
			{
				MessageBox.Show($"Los datos no son válidos. {ex.Message} Reingrese.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (FormatException)
			{
				MessageBox.Show("El campo \"DNI\" solo acepta números. Reingrese.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			DialogResult res = MessageBox.Show("Seguro que desea cancelar la acción?",
						"Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (res == DialogResult.Yes)
			{
				this.Close();
			}
		}
	}
}
