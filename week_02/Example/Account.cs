namespace Examples
{
    class Account
    {
        // instance variables
        private decimal balance;

        // auto implemented property
        public string Name { get; set; }

        // constructor (name same as Class, no return type)
        public Account(string name, decimal initialBalance = 0.0m)
        {
            Name = name.Trim();
            Balance = initialBalance;
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }
            private set // only useable within class (constructor call)
            {
                if (value > 0.0m) // m => double
                {
                    balance = value;
                }
            }
        }

        public void Deposit(decimal arg)
        {
            if (arg > 0.0m)
            {
                balance += arg;
            }
        }
    }
}
