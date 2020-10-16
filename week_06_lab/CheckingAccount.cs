
namespace week_06_lab
{
    class CheckingAccount: Account
    {
        private decimal fee;
        public CheckingAccount(decimal initialBalance, decimal fee): base(initialBalance)
        {
            this.fee = fee;
        }

        public override void Credit(decimal arg)
        {
            base.Credit(arg - fee);
        }

        public override bool Debit(decimal arg)
        {
            bool success = base.Debit(arg + fee);
            return success;
        }
    }
}
