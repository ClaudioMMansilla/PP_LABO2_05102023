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
        { }

        public void ActualizaHistorialDeOperaciones(char operador)
        { }

        public void EliminarHistorialDeOperaciones()
        { }

        private Numeracion MapeaResultado(double valor)
        { }

        public void Calcular()
        { }

        public void Calcular(char operador)
        { }
    }
}
