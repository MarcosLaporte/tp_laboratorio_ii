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
    public partial class FrmMontoSenia : Form
    {
        private float seniaVenta;
        private float precioVenta;

        public FrmMontoSenia()
        {
            InitializeComponent();
        }

        private void FrmMontoSenia_Load(object sender, EventArgs e)
        {
            this.rBtnCompleto.Text += $" ({this.precioVenta:C})";
        }

        public float SeniaVenta
        {
            get { return this.seniaVenta; }
        }
        public float PrecioVenta
		{
			set { this.precioVenta = value; }
		}

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool valorOk = true;
            float senia = -1;
			if (rBtnCompleto.Checked)
            {
                senia = -1;
            }
            else if (rBtnNada.Checked)
            {
                senia = 0;
            }
            else if (rBtnPersonalizado.Checked)
            {
                if(!float.TryParse(this.tBxSenia.Text, out float seniaIndicada) || seniaIndicada < 0)
                {
                    MessageBox.Show("Ingrese un valor válido.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valorOk = false;
                }
                else if(seniaIndicada > precioVenta)
				{
                    MessageBox.Show("No puede abonar de más.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valorOk = false;
                }
                else
                {
                    senia = seniaIndicada;
                }
			}
			else
			{
                MessageBox.Show("Debe seleccionar una casilla.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valorOk = false;
            }

            if (valorOk)
			{
                this.seniaVenta = senia;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

	}
}
