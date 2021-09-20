using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida el operador recibido
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Retorna el operador validado, si no es válido retorna "+"</returns>
        private static char ValidarOperador(char operador)
        {
            
            if(operador== '-' || operador=='+' || operador == '*' || operador=='/')
            {
                return operador;
            }
            return '+';
        }

        /// <summary>
        /// Realiza la operacion segun el operador recibido
        /// </summary>
        /// <param name="num1">Primer numero del calculo</param>
        /// <param name="num2">Snumero del calculo</param>
        /// <param name="operador">Operador del calculo</param>
        /// <returns>El resultado del calculo</returns>
        public static double Operar(Operando num1,Operando num2, char operador)
        {
            double resultado = 0;
            
            switch (ValidarOperador(operador))
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }
    }
}
