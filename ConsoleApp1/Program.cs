using Entidades;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string binario = String.Empty;
            ESistema sistema = new ESistema();
            Numeracion numUno = new Numeracion(120, sistema);
            Numeracion numDos = new Numeracion(20, sistema);
            Numeracion resultado = new Numeracion(0, sistema);
            Operacion operador = new Operacion(numUno, numDos);

            Console.WriteLine($"num valor {numUno.Valor}, sistema {numUno.Sistema}");
            binario = numUno.ConvertirA(ESistema.Binario);
            Console.WriteLine($"Binario {binario}, sistema {ESistema.Binario}");

            resultado = operador.Operar('+');
            Console.WriteLine($"Resultado: {resultado.Valor}");
        }
    }
}