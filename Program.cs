namespace TaskTwo
{
    //ParantClass(Base class)
    public class BankAccount
    {
        //Proberties
        protected string Name { get; set; }
        protected int AccountNumber { get; set; }
        protected decimal Balance { get; set; }
        //Constractor (Parametrized)
        public BankAccount(string name,int accountNumber, decimal balance)
        {
            Name = name;
            AccountNumber = accountNumber;
            Balance = balance;
        }
        //virtual Method
        public virtual decimal CalculateInterest()
        {
            return 0;
        }
        //Dispaly info
        public virtual void ShowAccountDetails()
        {
            Console.WriteLine($"Customar Name : {Name}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: {Balance}");
        }
    }
    //Child Class 
    public class SavingAccount : BankAccount
    {
        public decimal InterestRate { get; set; }

        public SavingAccount(string name,int accountNumber, decimal balance, decimal interestRate)
            : base(name,accountNumber, balance)
        {
            InterestRate = interestRate;
        }
        //override method
        public override decimal CalculateInterest()
        {
            return Balance * InterestRate / 100;
        }
        //Dispaly info overrided
        public override void ShowAccountDetails()
        {
            base.ShowAccountDetails();
            Console.WriteLine($"Interest Rate: {InterestRate}%");
        }
    }
    public class CurrentAccount : BankAccount
    {
        public decimal OverdraftLimit { get; set; }

        public CurrentAccount(string name,int accountNumber, decimal balance, decimal overdraftLimit)
            : base(name,accountNumber, balance)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override decimal CalculateInterest()
        {
            return 0;
        }

        public override void ShowAccountDetails()
        {
            base.ShowAccountDetails();
            Console.WriteLine($"Overdraft Limit: {OverdraftLimit}");
        }
    }

    class Program
    {
        static void Main()
        {
            SavingAccount s = new SavingAccount("Ahmed",10661, 5000, 5);
            CurrentAccount c = new CurrentAccount("Karim", 20012, 3000, 1000); 
            List<BankAccount> accounts = new List<BankAccount>
            {
                s,c
            };
            foreach (var account in accounts)
            {
                account.ShowAccountDetails();
                Console.WriteLine($"Calculated Interest: {account.CalculateInterest():C}");
                Console.WriteLine("**------------------------------------------**");
            }
        }
    }
}
