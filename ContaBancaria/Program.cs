using System;
using System.Globalization;

namespace ContaBancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            double valor;
            Conta conta;

            Console.WriteLine("Abertura de Conta");
            Console.Write("Digite o número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do titular da conta: ");
            string titular = Console.ReadLine();

            Console.Write("Haverá depósito inicial (s/n)? ");
            char resposta = char.Parse(Console.ReadLine());

            if (char.ToLower(resposta).Equals('s'))
            {
                Console.Write("Digite o valor: ");
                valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta = new Conta(numero, titular, valor);
            }
            else
            {
                conta = new Conta(numero, titular);
            }

            Console.WriteLine("Dados da conta: ");
            Console.WriteLine(conta);

            Console.Write("Digite um valor para depósito: ");
            valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            conta.Depositar(valor);

            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(conta);

            Console.Write("Digite um valor para saque: ");
            valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            conta.Sacar(valor);

            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(conta);
        }
    }
}
