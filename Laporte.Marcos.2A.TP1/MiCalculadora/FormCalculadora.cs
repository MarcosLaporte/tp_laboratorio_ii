using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Carga el form. Agrega al comboBox los operadores disponibles y deja el label y las textBoxs vacías.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.cmbOperador.Items.Add("");
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("/");
            this.cmbOperador.Items.Add("*");
            Limpiar();
        }
        /// <summary>
        /// Se encarga de validar que los campos no estén vacíos o tengan 0s
        ///     innecesarios e imprime los valores con su resultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            //Valido que el primer número no esté vacío, si lo está, lo establezco como 0.
            if (this.txtNumero1.Text == "")
            {
                this.txtNumero1.Text = "0";
            }

            //Valido que el segundo número no esté vacío, si lo está, lo establezco como 0.
            if (this.txtNumero2.Text == "")
            {
                this.txtNumero2.Text = "0";
            }

            //Valido que el operador no esté vacío, si lo está, lo establezco como '+'.
            if (this.cmbOperador.Text == "")
            {
                this.cmbOperador.Text = "+";
            }

            string numero1 = this.txtNumero1.Text;
            string numero2 = this.txtNumero2.Text;
            string operador = this.cmbOperador.Text;

            double.TryParse(numero1, out double aux1);
            double.TryParse(numero2, out double aux2);
            //Mientras que los números no sean solo 0, que los borre.
            if (aux1 == 0)
            {
                numero1 = "0";
            }
            else
            {
                numero1 = numero1.TrimStart('0');
            }

            if (aux2 == 0)
            {
                numero2 = "0";
            }
            else
            {
                numero2 = numero2.TrimStart('0');
            }

            string resultado = Operar(numero1, numero2, operador).ToString();
            if(resultado == double.MinValue.ToString())
            {
                this.lblResultado.Text = "No se puede dividir por 0";
                this.lstOperaciones.Items.Add($"{numero1} {operador} {numero2} = ERROR");
            }
            else
            {
                this.lblResultado.Text = resultado;
                this.lstOperaciones.Items.Add($"{numero1} {operador} {numero2} = {resultado}");
            }
        }
        /// <summary>
        /// Deja el label y las textBoxs vacías.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = String.Empty;
            this.txtNumero2.Text = String.Empty;
            this.cmbOperador.SelectedItem = " ";
            this.lblResultado.Text = String.Empty;
        }
        /// <summary>
        /// Utiliza el método 'Operar' de la clase Calculadora.
        /// </summary>
        /// <param name="numero1">Primer número</param>
        /// <param name="numero2">Segundo número</param>
        /// <param name="operador">El operador de la cuenta</param>
        /// <returns>El valor de la cuenta</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            //Reemplaza los puntos por comas para que lo tome como número con decimales.
            numero1 = numero1.Replace('.', ',');
            numero2 = numero2.Replace('.', ',');

            Operando primNumero = new Operando(numero1);
            Operando segNumero = new Operando(numero2);
            char.TryParse(operador, out char auxOperador);

            return Calculadora.Operar(primNumero, segNumero, auxOperador);
        }
        /// <summary>
        /// Llama al método Limpiar() para que borre el label y los textBoxs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Llama al método Close(), para que utilice el FormClosing, el cual pide validación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Utiliza el método DecimalBinario de la clase Operando e imprime el resultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numeroBinario = new Operando(this.lblResultado.Text);
            string resultado = numeroBinario.DecimalBinario(this.lblResultado.Text);

            if (resultado != "Valor inválido.")
            {
                this.lstOperaciones.Items.Add($"{this.lblResultado.Text}D = {resultado}B");
            }
            this.lblResultado.Text = resultado;
        }
        /// <summary>
        /// Utiliza el método BinarioDecimal de la clase Operando e imprime el resultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numeroDecimal = new Operando();
            string resultado = numeroDecimal.BinarioDecimal(this.lblResultado.Text);
            if(resultado != "Valor inválido.")
            {
                this.lstOperaciones.Items.Add($"{this.lblResultado.Text}B = {resultado}D");
            }
            this.lblResultado.Text = resultado;
        }
        /// <summary>
        /// Pide una validación al querer cerrar el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
