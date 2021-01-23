using System;

namespace week_06_lab
{
    class CheckingAccount : Account
    {
        private decimal fee;
        public CheckingAccount(decimal initialBalance, decimal fee) : base(initialBalance)
        {
            Fee = fee;
        }

        private decimal Fee
        {
            set
            {
                if (value >= 0) fee = value;
                else throw new Exception("fee can't be negative");
            }
        }

        public override void Credit(decimal arg)
        {
            if (arg >= fee) base.Credit(arg - fee);
            else Console.WriteLine($"Insufficent credit amount");
        }

        public override bool Debit(decimal arg)
        {
            if (arg > 0) return base.Debit(arg + fee);
            else Console.WriteLine($"Debit amount can't be negative");
            return false;
        }
    }
}
