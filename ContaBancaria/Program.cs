using ContaBancaria.Entities;
using System;
using System.Globalization;

namespace ContaBancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            double valor;
            Account acc;

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
                acc = new Account(numero, titular, valor);
            }
            else
            {
                acc = new Account(numero, titular);
            }

            Console.WriteLine("Dados da conta: ");
            Console.WriteLine(acc);

            Console.Write("Digite um valor para depósito: ");
            valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            acc.Deposit(valor);

            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(acc);

            Console.Write("Digite um valor para saque: ");
            valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            acc.Withdraw(valor);

            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(acc);
        }
    }
}
