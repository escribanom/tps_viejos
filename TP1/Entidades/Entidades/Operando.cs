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
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }
        /// <summary>
        /// Constructor de clase
        /// </summary>
        public Operando() : this(0)
        {
         
        }
        /// <summary>
        /// Constructor de clase inicializado por parámetrode tipo double
        /// </summary>
        public Operando(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor de clase inicializado por parámetro de tipo string
        /// </summary>
        public Operando(string strOperando)
        {
            this.Numero = strOperando;
        }
        /// <summary>
        /// Valida y asigna un valor de tipo double
        /// </summary>
        private double ValidarOperando(string strNumero)
        {
            if(Double.TryParse(strNumero, out double operando))
            {
                return operando;
            }
            return 0;
        }
        /// <summary>
        /// Verifica que el parámetro string recibido sea un numero binario
        /// </summary>
        /// <param name="binario">numero a convertir</param>
        /// <returns>Retorna true si es binario, caso contrario devuelve false</returns>
        private bool EsBinario(string binario)
        {
            bool retorno = false;
            for(int i=0;i<binario.Length;i++)
            {
                if (binario[i]==0 || binario[i]==1)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Convierte un numero binario a numero decimal
        /// </summary>
        /// <param name="binario">numero a convertir</param>
        /// <returns>Si pudo convertir retorna un string con el numero decimal cargado, caso contrario devuelve un string cargado con "Valor inválido"</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor Inválido";
            double auxNum=0;
            int potencia = 0;
            if (!String.IsNullOrEmpty(binario) && EsBinario(binario))
            {
                 for(int i= binario.Length - 1; i >= 0; i--)
                {
                    if(binario[i]=='1')
                    {
                        auxNum += Math.Pow(2, potencia);
                    }
                    potencia++;
                }
                retorno = auxNum.ToString();
            }
            return retorno;
        }
        /// <summary>
        /// Convierte un numero decimal a numero binario
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns>Si pudo convertir retorna un string con el numero binario cargado, caso contrario devuelve un string cargado con "Valor inválido"</returns>
        public string DecimalBinario(double numero)
        {
            string auxBin = String.Empty;
            int auxDecimal = (int)Math.Abs(numero);
            if(auxDecimal==0)
            {
                auxBin = "0";
            }
            while(auxDecimal>0)
            {
                auxBin = (int)auxDecimal % 2 + auxBin;
                auxDecimal = (int)auxDecimal / 2;
            }
            return auxBin;
        }
        /// <summary>
        /// Convierte un numero decimal a numero binario
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns>Si pudo convertir retorna un string con el numero binario cargado, caso contrario devuelve un string cargado con "Valor inválido"</returns>
        public string DecimalBinario(string numero)
        {
            if(Double.TryParse(numero, out double auxDec))
            {
                return DecimalBinario(auxDec);
            }
            else
            {
                return "Valor Inválido";
            }
        }
        /// <summary>
        /// Sobrecarga del operador -
        /// </summary>
        /// <param name="n1">primer numeor a restar</param>
        /// <param name="n2">segundo numero a reestar</param>
        /// <returns>La resta de los 2 objetos recibidos</returns>
        public static double operator -(Operando n1,Operando n2)
        {
            return (n1.numero - n2.numero);
        }
        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="n1">primer numeor a sumar</param>
        /// <param name="n2">segundo numero a sumar</param>
        /// <returns>La suma de los 2 objetos recibidos</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return (n1.numero + n2.numero);
        }
        /// <summary>
        /// Sobrecarga del operador *
        /// </summary>
        /// <param name="n1">primer numeor a multiplicar</param>
        /// <param name="n2">segundo numero a multiplicar</param>
        /// <returns>La multiplicacion de los 2 objetos recibidos</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return (n1.numero * n2.numero);
        }
        /// <summary>
        /// Sobrecarga del operador /
        /// </summary>
        /// <param name="n1">primer numeor a dividir</param>
        /// <param name="n2">segundo numero a dividir</param>
        /// <returns>La division entre los 2 objetos recibidos</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double auxDiv;
            if(n2.numero==0)
            {

                auxDiv= double.MinValue; 
            }
            else
            {
                auxDiv= (n1.numero / n2.numero);
            }
            return auxDiv;
        }
    }
}
