
namespace week_06_lab
{
    class SavingsAccount: Account
    {
        private decimal interestRate;
        public SavingsAccount(decimal initialBalance, decimal interestRate): base(initialBalance)
        {
            this.interestRate = interestRate;
        }

        public decimal CalculateInterest()
        {
            return interestRate * Balance;
        }
    }
}
