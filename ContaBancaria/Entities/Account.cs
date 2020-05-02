using System.Globalization;

namespace ContaBancaria.Entities
{
    class Account
    {
        private static readonly double TaxaDeSaque = 5;
        public int Number { get; protected set; }
        public string Holder { get; protected set; }
        public double Balance { get; protected set; }

        public Account()
        {
        }

        public Account(int number, string holder)
        {
            Number = number;
            Holder = holder;
        }

        public Account(int number, string holder, double initialBalance) : this(number, holder)
        {
            Deposit(initialBalance);
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            Balance -= amount + TaxaDeSaque;
        }

        public override string ToString()
        {
            return $"Conta {Number}, Titular: {Holder}, Saldo: R$ {Balance.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
