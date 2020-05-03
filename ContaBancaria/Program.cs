using ContaBancaria.Entities;
using ContaBancaria.Entities.Exceptions;
using System;
using System.Globalization;

namespace ContaBancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double valor;
                Account acc;

                Console.WriteLine("Abertura de Conta");
                Console.Write("Digite o número da conta: ");
                int numero = int.Parse(Console.ReadLine());

                Console.Write("Digite o nome do titular da conta: ");
                string titular = Console.ReadLine();

                Console.Write("Digite o limite para saque: ");
                double limite = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Haverá depósito inicial (s/n)? ");
                char resposta = char.Parse(Console.ReadLine());

                if (char.ToLower(resposta).Equals('s'))
                {
                    Console.Write("Digite o valor: ");
                    valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    acc = new Account(numero, titular, valor, limite);
                }
                else
                {
                    acc = new Account(numero, titular, limite);
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
            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Erro de formatação: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro inesperado: {e.Message}");
            }
        }
    }
}
