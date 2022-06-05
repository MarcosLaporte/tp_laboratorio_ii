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
        private float seniaCompra;

        public FrmMontoSenia()
        {
            InitializeComponent();
        }

        public float SeniaCompra
        {
            get { return this.seniaCompra; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (rBtnCompleto.Checked == false && rBtnNada.Checked == false
                && rBtnPersonalizado.Checked == false)
            {
                MessageBox.Show("ERROR!", "Debe seleccionar una casilla.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rBtnCompleto.Checked)
                {
                    //rBtnNada.Checked = false;
                    //rBtnPersonalizado.Checked = false;
                    this.seniaCompra = -1;
                }
                else if (rBtnNada.Checked)
                {
                    //rBtnCompleto.Checked = false;
                    //rBtnPersonalizado.Checked = false;
                    this.seniaCompra = 0;
                }
                else
                {
                    //rBtnCompleto.Checked = false;
                    //rBtnPersonalizado.Checked = false;
                    if(!float.TryParse(this.tBxSenia.Text, out float senia) || senia <= 0)
                    {
                        MessageBox.Show("ERROR!", "Ingrese un valor válido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.seniaCompra = senia;
                    }
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
