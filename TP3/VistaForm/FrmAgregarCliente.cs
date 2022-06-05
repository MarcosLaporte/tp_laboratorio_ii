using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace VistaForm
{
    public partial class FrmAgregarCliente : Form
    {
        private Cliente clienteCreado;
        public FrmAgregarCliente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = this.tBxNombre.Text;
            string apellido = this.tBxApellido.Text;
            string telefono = this.tBxTelefono.Text;
            string dni = this.tBxDni.Text;


            if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(apellido)
                || !EsCadenaNumerica(telefono) || !EsCadenaNumerica(dni))
            {
                MessageBox.Show("Los datos no son válidos.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.clienteCreado = new Cliente(nombre, apellido, telefono, dni);
                this.DialogResult = DialogResult.OK;
            }
        }

        public Cliente GetCliente()
        {
            return this.clienteCreado;
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

        private static bool EsCadenaNumerica(string cadena)
        {
            bool ret = true;

            if (!string.IsNullOrEmpty(cadena))
            {
                foreach (char item in cadena)
                {
                    if (!char.IsDigit(item))
                    {
                        ret = false;
                        break;
                    }
                }
            }
            else
            {
                ret = false;
            }

            return ret;
        }
    }
}
