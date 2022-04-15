using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el caracter ingresado sea un operador matemático (+,-,*,/), y si no lo es, retorna un '+'.
        /// </summary>
        /// <param name="operador">Caracter a validar</param>
        /// <returns>El caracter validado, o en su efecto, un '+'.</returns>
        private static char ValidarOperador(char operador)
        {
            char aux = operador;
            if (operador != '+' && operador != '-' && operador != '*' && operador != '/')
            {
                aux = '+';
            }

            return aux;
        }
        /// <summary>
        /// Realiza la operación correspondiente al operador pasado por parámetro.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>El valor de la cuenta realizada.</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;

            switch (ValidarOperador(operador))
            {
                case '+':
                    resultado = Math.Round(num1 + num2, 2);
                    break;
                case '-':
                    resultado = Math.Round(num1 - num2, 2);
                    break;
                case '*':
                    resultado = Math.Round(num1 * num2, 2);
                    break;
                case '/':
                    resultado = Math.Round(num1 / num2, 2);
                    break;
            }

            return resultado;
        }
    }
}
