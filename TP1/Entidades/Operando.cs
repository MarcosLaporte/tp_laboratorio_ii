using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Valida un número y lo asigna al atributo 'numero'.
        /// </summary>
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }
        /// <summary>
        /// Convierte un binario a decimal.
        /// </summary>
        /// <param name="binario">El binario a convertir</param>
        /// <returns>Número decimal en string si pudo, o "Valor inválido." si no.</returns>
        public string BinarioDecimal(string binario)
        {
            string numDecimal = "";
            long total = 0;
            if (EsBinario(binario))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    int aux = (int)Char.GetNumericValue(binario[i]);
                    total = total * 2 + aux;
                }
                numDecimal = total.ToString();
            }
            else
            {
                numDecimal = "Valor inválido.";
            }
            
            return numDecimal;
        }
        /// <summary>
        /// Convierte un decimal en formato string a binario.
        /// </summary>
        /// <param name="numero">Decimal a convertir</param>
        /// <returns>Número binario en string si pudo, o "Valor inválido." si no.</returns>
        public string DecimalBinario(string numero)
        {
            string numBinario = "";
            if (long.TryParse(numero, out long auxNumero) && auxNumero >= 0)
            {
                if (auxNumero > 0)
                {
                    for (int i = 0; auxNumero > 0; i++)
                    {
                        numBinario = $"{(int)auxNumero % 2}" + numBinario;
                        auxNumero /= 2;
                    }
                }
                else
                {
                    numBinario = "0";
                }
            }
            else
            {
                numBinario = "Valor inválido.";
            }

            return numBinario;
        }
        /// <summary>
        /// Convierte un decimal en formato double a binario.
        /// </summary>
        /// <param name="numero">Decimal a convertir</param>
        /// <returns>Número binario en string si pudo, o "Valor inválido." si no.</returns>
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }
        /// <summary>
        /// Valida que el número sea binario.
        /// </summary>
        /// <param name="binario">Número a validar</param>
        /// <returns>true si es binario, false si no.</returns>
        private bool EsBinario(string binario)
        {
            bool ret = true;
            foreach (char aux in binario)
            {
                if (aux != '0' && aux != '1')
                {
                    ret = false;
                    break;
                }
            }

            return ret;
        }
        /// <summary>
        /// Asigna un valor predeterminado al atributo 'numero'.
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Asigna al atributo 'numero' el valor pasado por parámetro.
        /// </summary>
        /// <param name="numero">Valor a asignar</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Utiliza la propiedad 'Numero' para validar un valor y asignarlo al atributo 'numero'.
        /// </summary>
        /// <param name="strNumero">Valor a asignar en string</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// Sobrecarga del operador '-'.
        /// </summary>
        /// <param name="num1">Primer número</param>
        /// <param name="num2">Segundo número</param>
        /// <returns>El resultado de la resta.</returns>
        public static double operator - (Operando num1, Operando num2)
        {
            return num1.numero - num2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador '+'.
        /// </summary>
        /// <param name="num1">Primer número</param>
        /// <param name="num2">Segundo número</param>
        /// <returns>El resultado de la suma.</returns>
        public static double operator + (Operando num1, Operando num2)
        {
            return num1.numero + num2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador '*'.
        /// </summary>
        /// <param name="num1">Primer número</param>
        /// <param name="num2">Segundo número</param>
        /// <returns>El resultado de la multiplicación.</returns>
        public static double operator * (Operando num1, Operando num2)
        {
            return num1.numero * num2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador '/', con una asignación específica al dividir por 0.
        /// </summary>
        /// <param name="num1">Primer número</param>
        /// <param name="num2">Segundo número</param>
        /// <returns>El resultado de la división, si es válida.</returns>
        public static double operator / (Operando num1, Operando num2)
        {
            double res = double.MinValue;
            if(num2.numero != 0)
            {
                res = num1.numero / num2.numero;
            }

            return res;
        }

        /// <summary>
        /// Valida que el valoringresado por parámetro sea un número.
        /// </summary>
        /// <param name="strNumero">Valor a validar</param>
        /// <returns>El número ingresado si es válido, o 0 si no.</returns>
        private double ValidarOperando(string strNumero)
        {
            double aux = 0;
            if (double.TryParse(strNumero, out double numero))
            {
                aux = numero;
            }

            return aux;
        }
    }
}
