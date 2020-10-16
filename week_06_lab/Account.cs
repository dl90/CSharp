using System;

namespace week_06_lab
{
    class Account
    {
        private decimal balance;

        protected Account(decimal initialBalance )
        {
            Balance = initialBalance;
        }

        internal decimal Balance
        {
            get
            {
                return balance;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception($"Invalid initial balance: {value}");
                }
                balance = value;
            }
        }

        public virtual void Credit(decimal arg)
        {
            if (arg < 0)
            {
                throw new Exception($"Invalid credit value: {arg}");
            }
            Balance += arg;
        }

        public virtual bool Debit(decimal arg)
        {
            bool success;
            if (arg < 0)
            {
                throw new Exception($"Invalid debit value {arg}");
            }
            else if (arg > Balance)
            {
                Console.WriteLine("Debit amount exceeded account balance.");
                success =  false;
            }
            else
            {
                Balance -= arg;
                success = true;
            }
            return success;
        }
    }
}
