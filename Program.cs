using System;

namespace taxas
{
    class Program
    {
        static void Main(string[] args)
        {

            Parametros calculo = new Parametros();

            Console.WriteLine("Bem Vindo a Calculadora de Investimentos!");

            double valorI;
            Console.WriteLine("qual o Valor inicial Investido?");
            valorI = Convert.ToDouble(Console.ReadLine());

            double valorM;
            Console.WriteLine("qual o Valor mensal Investido?");
            valorM = Convert.ToDouble(Console.ReadLine());
            double valorMJ = valorM;

            int tempoI;
            Console.WriteLine("Por conta tempo Você Investirá?");
            tempoI = Convert.ToInt32(Console.ReadLine());

            int opcao;
            int poupanca = 1;
            int tSelic = 2;
            int fixa = 3;

            Console.WriteLine("qual a sua forma de investimento?");
            Console.WriteLine("[1] Poupança, [2] Tesouro Selic, [3] Pré-Fixado");
            opcao = Convert.ToInt32(Console.ReadLine());

          
            if (opcao == poupanca)
            {
                // A poupanção, quando a selic esta abaixo de 8.5, paga apenas 70% da mesma...
                double valorP = (calculo.taxa / 100.0) * 70.0;
                calculo.taxa = valorP + 1;               
            }

           
            if (opcao == tSelic)
            {
                // o "+ 1" é necessario para o calculo dos juros compostos
                calculo.taxa = calculo.selic + 1;
            }

            
            if (opcao == fixa)
            {
                double valorFixo;
                Console.WriteLine("qual a Porcentagem anual?");
                valorFixo = Convert.ToDouble(Console.ReadLine());
               
                calculo.taxa = (valorFixo / 10000) + 1;
            }

            //calculador juros compostos do valor inicial
            for (int i = 1; i <= tempoI; i++)
            {
                valorI *= calculo.taxa;
            }

            //calculador juros compostos do valor mensal aplicado
            for (int i = 1; i <= tempoI; i++)
            {
                valorMJ *= calculo.taxa;
                if (i < tempoI)
                {
                    // realiza a adição do valor aplicado mensalmente
                    valorMJ += valorM;
                }
            }

            double valorF = valorMJ + valorI;

            Console.WriteLine("O valor final Investido será de " + Math.Round(valorF, 2));

        }
    }
}
