using Entidades;
using Entidades.Excepciones;
using System;
using System.Windows.Forms;

namespace VistaForm
{
	public partial class FrmAgregarCliente : Form
	{
		private Cliente clienteCreado;
		public FrmAgregarCliente()
		{
			InitializeComponent();
		}

		public Cliente ClienteCreado
		{
			get { return this.clienteCreado; }
			set { clienteCreado = value; }
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			string nombre = this.tBxNombre.Text;
			string apellido = this.tBxApellido.Text;
			string telefono = this.tBxTelefono.Text;

			try
			{
				ulong dni = ulong.Parse(this.tBxDni.Text);
				this.ClienteCreado = new Cliente(nombre, apellido, telefono, dni);
				this.DialogResult = DialogResult.OK;
			}
			catch (NullReferenceException)
			{
				MessageBox.Show("Ningún campo puede quedar vacío. Reingrese.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (ClienteInvalidoException)
			{
				MessageBox.Show("Los datos no son válidos. Reingrese.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
