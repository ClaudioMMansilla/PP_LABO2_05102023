using System;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private string nombreAlumno;
        private List<string> operaciones;
        private Numeracion primerOperando;
        private Numeracion resultado;
        private Numeracion segundoOperando;
        private static ESistema sistema;

        public string NombreAlumno
        {
            get 
            {
                return this.nombreAlumno;
            }
            set 
            {
                this.nombreAlumno = value;
            }
        }

        public Numeracion PrimerOperando
        {
            get 
            { 
                return this.primerOperando; 
            }
            set 
            { 
                this.primerOperando = value; 
            }
        }

        public Numeracion SegundoOperando
        {
            get 
            {
                return this.segundoOperando; 
            }
            set 
            { 
                this.segundoOperando = value; 
            }
        }

        public Numeracion Resultado
        {
            get 
            { 
                return this.resultado; 
            }
        }

        public List<string> Operaciones
        {
            get
            {
                return this.operaciones;
            }
        }

        public static ESistema Sistema
        { 
            get 
            {
                return Calculadora.sistema;
            }
            set 
            {
                Calculadora.sistema = value;
            }
        }

        static Calculadora()
        { 
            Calculadora.sistema = ESistema.Decimal; 
        }

        public Calculadora()
        {
            this.operaciones = new List<string>();  
        }

        public Calculadora(string nombreAlumno)
            : this()
        {
            this.nombreAlumno = nombreAlumno;
        }

        public void ActualizaHistorialDeOperaciones(char operador)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Sistema: {Calculadora.Sistema}");
            sb.AppendLine($"Primer Op: {this.primerOperando.Valor}");
            sb.AppendLine($"Segundo Op: {this.segundoOperando.Valor}");
            sb.AppendLine($"Operador: {operador}");
            operaciones.Add( sb.ToString() );
        }

        public void EliminarHistorialDeOperaciones()
        { 
            this.operaciones.Clear();
        }

        private Numeracion MapeaResultado(double valor)
        {
            Numeracion num;

            if(Calculadora.sistema == ESistema.Decimal)
            {
                num = new SistemaDecimal(valor.ToString());
            }
            else if(Calculadora.sistema == ESistema.Binario)
            {
                num = new SistemaBinario(valor.ToString());
            }
            else
            {
                num = new SistemaDecimal(double.MinValue.ToString());
            }

            return num;
        }

        public void Calcular()
        {
            this.Calcular('+');
        }

        public void Calcular(char operador)
        {
            double primerOp = (double)this.primerOperando;
            double segundoOp = (double)this.segundoOperando;
            double resultadoAux;

            if (this.primerOperando != this.segundoOperando)
            {
                resultadoAux = 0;
            }

            else 
            {
                switch (operador)
                { // (+, -,*, /)
                    case '-':
                        resultadoAux = primerOp - segundoOp;
                        break;
                    case '*':
                        resultadoAux = primerOp * segundoOp;
                        break;
                    case '/':
                        resultadoAux = primerOp / segundoOp;
                        break;
                    default:
                        resultadoAux = primerOp + segundoOp;
                        break;
                }
            }

            this.resultado = this.MapeaResultado(resultadoAux);
        }
    }
}
