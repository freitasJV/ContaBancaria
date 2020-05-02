namespace ContaBancaria.Entities
{
    class BusinessAccount : Account
    {
        public double LoanLimit { get; set; }

        public BusinessAccount()
        {
        }

        public BusinessAccount (int number, string holder, double initialBalance, double loanLimit) : base(number, holder, initialBalance)
        {
            LoanLimit = loanLimit;
        }

        public void Loan (double amount)
        {
            if(amount <= LoanLimit)
            {
                Balance += LoanLimit;
            }
        }
    }
}
