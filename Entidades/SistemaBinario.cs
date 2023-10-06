using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaBinario : Numeracion
    {
        internal override double ValorNumerico
        {
            get
            {
                return (double)this;
            }
        }

        public SistemaBinario(string valor)
            : base(valor) { }

        public override Numeracion CambiarSistemaDeNumeracion(ESistema sistema)
        {
            if (sistema == ESistema.Decimal)
            {
                return this.BinarioADecimal();
            }
            return this;
        }


        /*
        f.El método BinarioADecimal verificará que el valor de la instancia no
          posea un msgError y convertirá este a SistemaDecimal.Caso contrario
          devolverá el mínimo de un double.
        */
        private SistemaDecimal BinarioADecimal()
        {
            if (this.Valor != Numeracion.msgError)
            {
                double resultado = 0;
                int cantidadCaracteres = this.Valor.Length;
                foreach (char c in this.Valor)
                {
                    cantidadCaracteres--;
                    if (c == '1')
                    {
                        resultado += (int)Math.Pow(2, cantidadCaracteres);
                    }
                }
                return resultado;
            }

            return double.MinValue;
        }

        private bool EsSistemaBinarioValido(string valor)
        {
            foreach (char c in valor)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }

        protected override bool EsNumeracionValida(string valor)
        {
            return base.EsNumeracionValida(valor) && this.EsSistemaBinarioValido(valor);
        }

        public static implicit operator SistemaBinario(string valor)
        {
            return new SistemaBinario(valor);
        }

    }
}
