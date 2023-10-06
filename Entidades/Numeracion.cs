using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Numeracion
    {
        protected static string msgError;
        protected string valor;

        public string Valor
        {
            get 
            { 
                return this.valor; 
            } 
        }

        internal abstract double ValorNumerico
        { get; }

        static Numeracion()
        { 
            Numeracion.msgError = "Numero Invalido"; 
        }

        protected Numeracion(string valor)
        {
            this.InicializaValor(valor);
        }

        private void InicializaValor(string valor)
        { 
            if(EsNumeracionValida(valor)) 
            {
                this.valor = valor;
            }
            else
            {
                this.valor = Numeracion.msgError;
            }
            
        }

        public abstract Numeracion CambiarSistemaDeNumeracion(ESistema sistema);

        protected virtual bool EsNumeracionValida(string valor)
        { 
            return !String.IsNullOrWhiteSpace(valor);
        }

        //Implementar una conversión explicita de Numeración a double. Esta devolverá el valor de la Numeración.
        public static explicit operator double (Numeracion numeracion)
        {
            return double.Parse(numeracion.Valor);
        }

        //Dos numeraciones serán iguales si no son nulas y son del mismo tipo.
        public static bool operator ==(Numeracion n1, Numeracion n2)
        {
            return n1 is not null && n2 is not null && n1.GetType() == n2.GetType();
        }

        public static bool operator !=(Numeracion n1, Numeracion n2)
        { return !(n1 == n2); }
    }
}
