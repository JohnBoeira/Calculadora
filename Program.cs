using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraDesktop
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string opcao = "";
            string[] resultados = new string[100];
            int contador = 0;

            while (!opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Selecione a operação: {0}1 para soma {0}2 para subtrair {0}3 para multiplicar {0}4 para dividir {0}5 para mostar resultados {0}---S Para sair", Environment.NewLine);
                opcao = Console.ReadLine();

                if (opcao == "1" || opcao == "2" || opcao == "3" || opcao == "4")
                {
                    Calculadora cal = new Calculadora();
                    cal.PedirValores();
                    if (cal.segundoValor == 0 && opcao == "4")
                    {
                        Console.WriteLine("Não é possível dividir por 0!");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        cal.Calculo(opcao, cal.primeiroValor, cal.segundoValor);
                    }

                    resultados[contador] = cal.primeiroValor.ToString() + cal.operadorSimbolo + cal.segundoValor.ToString() + "=" + cal.resultado;
                    Console.WriteLine(resultados[contador]);
                    Console.ReadLine();
                    contador++;
                    Console.Clear();
                    continue;
                }

                else if (opcao == "5")
                {
                    for (int i = 0; i < resultados.Length; i++)
                    {
                        Console.WriteLine(resultados[i]);
                    }
                }
                else
                {
                    Console.WriteLine("Operação inválida");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        public class Calculadora
        {
            public double primeiroValor, segundoValor, resultado;
            public string operadorSimbolo;
            public void PedirValores()
            {
                Console.WriteLine("Primeiro valor:");
                primeiroValor = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("segundo valor:");
                segundoValor = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
            }

            public void Calculo(string operador, double ValorPrimeiro, double ValorSegundo)
            {
                switch (operador)
                {
                    case "1": resultado = ValorPrimeiro + ValorSegundo; operadorSimbolo = "+"; break;
                    case "2": resultado = ValorPrimeiro - ValorSegundo; operadorSimbolo = "-"; break;
                    case "3": resultado = ValorPrimeiro * ValorSegundo; operadorSimbolo = "*"; break;
                    case "4": resultado = ValorPrimeiro / ValorSegundo; operadorSimbolo = "/"; break;

                }
            }
        }
    }
}
