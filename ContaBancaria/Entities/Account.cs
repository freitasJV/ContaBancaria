using ContaBancaria.Entities.Exceptions;
using System.Globalization;

namespace ContaBancaria.Entities
{
    public class Account
    {
        private static readonly double TaxaDeSaque = 5;
        public int Number { get; protected set; }
        public string Holder { get; protected set; }
        public double Balance { get; protected set; }
        public double WithDrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double withDrawLimit)
        {
            if (withDrawLimit <= 0)
            {
                throw new DomainException("Erro: limite de saque inválido");
            }

            Number = number;
            Holder = holder;
            WithDrawLimit = withDrawLimit;
        }

        public Account(int number, string holder, double initialBalance, double withDrawLimit) : this(number, holder, withDrawLimit)
        {
            Deposit(initialBalance);
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new DomainException("Erro: valor inválido");
            }
            Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            if(amount > WithDrawLimit)
            {
                throw new DomainException("Erro de Saque: limite de saque excedido");
            }

            //if (amount + TaxaDeSaque > Balance). Caso seja uma regra de negócio a conta não ficar negativada
            if (amount > Balance)
            {
                throw new DomainException("Não há saldo para sacar essa quantia");
            }

            if (amount <= 0)
            {
                throw new DomainException("Erro: valor inválido");
            }

            Balance -= amount + TaxaDeSaque;
        }

        public override string ToString()
        {
            return $"Conta {Number}, Titular: {Holder}, Saldo: R$ {Balance.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
