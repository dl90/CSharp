using System;

namespace week_06_lab
{
    class SavingsAccount: Account
    {
        private decimal interestRate;
        public SavingsAccount(decimal initialBalance, decimal interestRate): base(initialBalance)
        {
            InterestRate = interestRate;
        }

        private decimal InterestRate
        {
            set
            {
                if (value >= 0) interestRate = value;
                else throw new Exception("interest can't be negative");
            }
        }

        public decimal CalculateInterest()
        {
            return interestRate * Balance;
        }
    }
}
