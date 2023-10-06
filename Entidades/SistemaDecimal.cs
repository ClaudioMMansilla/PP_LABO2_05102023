using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaDecimal : Numeracion
    {
        internal override double ValorNumerico
        {
            get
            {
                return (double)this;
            }
        }

        public SistemaDecimal(string valor)
            : base(valor) { }

        public override Numeracion CambiarSistemaDeNumeracion(ESistema sistema)
        { 
            if(sistema == ESistema.Binario)
            {
                return this.DecimalABinario();
            }
            return this;
        }

        /*
        f.El método DecimalABinario verificará que el valor a convertir sea mayor
          que 0 (cero) y realizará la conversión de la parte entera de una
          Numeracion de tipo SistemaDecimal a SistemaBinario, caso contrario
          devolverá un msgError.
        */
        private SistemaBinario DecimalABinario()
        {
            string binarioStr = string.Empty; 
            int resultado = (int)((double)this);
            int resto;

            if (resultado > 0)
            {
                do
                {
                    resto = resultado % 2;
                    resultado = resultado / 2;
                    binarioStr = resto.ToString() + binarioStr;
                } while (resultado > 0);

                return new SistemaBinario(binarioStr);
            }
            return new SistemaBinario(Numeracion.msgError);
        }

        protected override bool EsNumeracionValida(string valor)
        {
            return base.EsNumeracionValida(valor) && this.EsSistemaDecimalValido(valor);
        }

        private bool EsSistemaDecimalValido(string valor)
        {
            double valorAux = 0;
            return double.TryParse(valor, out valorAux);
        }

        public static implicit operator SistemaDecimal(double valor)
        {
            return new SistemaDecimal(valor.ToString());
        }

        public static implicit operator SistemaDecimal(string valor)
        {
            return new SistemaDecimal(valor);
        }
    }
}
