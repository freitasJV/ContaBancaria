using Moq;
using ContaBancaria.Entities;
using ContaBancaria.Entities.Exceptions;
using Xunit;

namespace ContaBancariaTest
{
    public class AccountTest
    {
        [Fact]
        public void LimiteDeSaqueMenorQueZero_Erro()
        {
            int numero = 1;
            string titular = "teste";
            double limiteSaque = -300;

            var expectedMessage = "Erro: limite de saque inválido";
            var message = Assert.Throws<DomainException>(() => new Account(numero,titular,limiteSaque)).Message;

            Assert.Equal(expectedMessage, message);
        }

        [Fact]
        public void DepositoMenorQueZero_Erro()
        {
            int numero = 1;
            string titular = "teste";
            double limiteSaque = 300;
            double depositoInicial = -500;

            var expectedMessage = "Erro: valor inválido";
            var message = Assert.Throws<DomainException>(() => new Account(numero,titular, depositoInicial,limiteSaque)).Message;

            Assert.Equal(expectedMessage, message);
        }

        [Fact]
        public void LimiteDaSaque_Ok()
        {
            int numero = 1;
            string titular = "teste";
            double depositoInicial = 500;
            double limiteSaque = 300;

            var m_account = new Mock<Account>(MockBehavior.Default, numero, titular, depositoInicial, limiteSaque)
            {
                CallBase = true
            };

            var obj = m_account.Object;

            Assert.True(obj.WithDrawLimit > 0);
        }

        [Fact]
        public void Saque_OK()
        {
            int numero = 1;
            string titular = "teste";
            double depositoInicial = 500;
            double limiteSaque = 300;
            double saque = 200;

            var m_account = new Mock<Account>(MockBehavior.Default, numero, titular, depositoInicial, limiteSaque)
            {
                CallBase = true
            };

            var obj = m_account.Object;

            obj.Withdraw(saque);

            double esperado = 295; //há uma taxa de 5.00 para saque

            Assert.Equal(esperado, obj.Balance);
        }

        [Fact]
        public void Deposito_OK()
        {
            int numero = 1;
            string titular = "teste";
            double depositoInicial = 500;
            double limiteSaque = 300;
            double deposito = 200;

            var m_account = new Mock<Account>(MockBehavior.Default, numero, titular, depositoInicial, limiteSaque)
            {
                CallBase = true
            };

            var obj = m_account.Object;

            obj.Deposit(deposito);

            double esperado = 700;

            Assert.Equal(esperado, obj.Balance);
        }

        [Fact]
        public void SaqueMaiorQueLimite_Erro()
        {
            int numero = 1;
            string titular = "teste";
            double depositoInicial = 500;
            double limiteSaque = 300;
            double saque = 400;

            var m_account = new Mock<Account>(MockBehavior.Default, numero, titular, depositoInicial, limiteSaque)
            {
                CallBase = true
            };

            var obj = m_account.Object;

            var expectedMessage = "Erro de Saque: limite de saque excedido";
            var message = Assert.Throws<DomainException>(() => obj.Withdraw(saque)).Message;

            Assert.Equal(expectedMessage, message);
        }

        [Fact]
        public void SaqueMaiorQueSaldo_Erro()
        {
            int numero = 1;
            string titular = "teste";
            double depositoInicial = 200;
            double limiteSaque = 300;
            double saque = 250;

            var m_account = new Mock<Account>(MockBehavior.Default, numero, titular, depositoInicial, limiteSaque)
            {
                CallBase = true
            };

            var obj = m_account.Object;

            var expectedMessage = "Não há saldo para sacar essa quantia";
            var message = Assert.Throws<DomainException>(() => obj.Withdraw(saque)).Message;

            Assert.Equal(expectedMessage, message);
        }

        [Fact]
        public void ValorDeSaqueMenorQueZero_Erro()
        {
            int numero = 1;
            string titular = "teste";
            double depositoInicial = 200;
            double limiteSaque = 300;
            double saque = -250;

            var m_account = new Mock<Account>(MockBehavior.Default, numero, titular, depositoInicial, limiteSaque)
            {
                CallBase = true
            };

            var obj = m_account.Object;

            var expectedMessage = "Erro: valor inválido";
            var message = Assert.Throws<DomainException>(() => obj.Withdraw(saque)).Message;

            Assert.Equal(expectedMessage, message);
        }
    }
}
