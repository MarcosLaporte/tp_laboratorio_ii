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
    public delegate void DelegadoSeniaInvalida(float valor);
    public partial class FrmMontoSenia : Form
    {
        public event DelegadoSeniaInvalida SeniaInvalida;

        private float seniaVenta;
        private float precioVenta;

        public FrmMontoSenia()
        {
            InitializeComponent();
        }

        private void FrmMontoSenia_Load(object sender, EventArgs e)
        {
            this.rBtnCompleto.Text += $" ({this.precioVenta:C})";
            SeniaInvalida += ManejadorSeniaInvalida;
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
                    MessageBox.Show("Ingrese un valor válido.", "Monto inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valorOk = false;
                }
                else if(seniaIndicada > precioVenta)
				{
                    MessageBox.Show("No puede abonar de más.", "Monto inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valorOk = false;
                }
                else if(seniaIndicada < precioVenta * 0.5)
				{
                    SeniaInvalida?.Invoke(seniaIndicada);
                    senia = 0;
				}
                else
                {
                    senia = seniaIndicada;
                }
			}
			else
			{
                MessageBox.Show("Debe seleccionar una opción.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void ManejadorSeniaInvalida(float valor)
		{
            MessageBox.Show($"No puede abonar menos que el 5% del total.\nSus {valor:C} se tomará como $0.", "Monto inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
