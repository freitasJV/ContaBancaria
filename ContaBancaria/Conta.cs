using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ContaBancaria
{
    class Conta
    {
        private static readonly double TaxaDeSaque = 5;
        public int Numero { get; private set; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }

        public Conta(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
        }

        public Conta(int numero, string titular, double depositoInicial) : this(numero, titular)
        {
            Depositar(depositoInicial);
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        public void Sacar(double valor)
        {
            Saldo -= valor + TaxaDeSaque;
        }

        public override string ToString()
        {
            return $"Conta {Numero}, Titular: {Titular}, Saldo: R$ {Saldo.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
