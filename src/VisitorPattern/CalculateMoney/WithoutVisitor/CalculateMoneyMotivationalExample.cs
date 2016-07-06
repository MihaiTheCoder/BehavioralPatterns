using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorPattern.CalculateMoney.WithoutVisitor
{
    public class CalculateMoneyMotivationalExample
    {
        public static void Run()
        {
            var suspect = new CorruptionSuspect();

            suspect.MoneyBankAccounts.Add(new MoneyBankAccount { Ammount = 50000, InterestPerMonth = 0.00, Bank = "ING" });
            suspect.MoneyBankAccounts.Add(new MoneyBankAccount { Ammount = 100000, InterestPerMonth = 0.02, Bank = "Bank of Uzbezkistan" });
            suspect.MoneyBankAccounts.Add(new MoneyBankAccount { Ammount = 50000, InterestPerMonth = 0.01, Bank = "Bank of Libia" });

            suspect.Valuables.Add(new Clock { EstimatedValue = 2500, InterestPerMonth = 0.00 });
            suspect.Valuables.Add(new RealEstate { EstimatedValue = 250000, InterestPerMonth = 0.25 });

            suspect.Loans.Add(new Loan { MonthlyPayment = 4000, Owed = 100000 });

            Console.WriteLine("Monthly income: {0} ", suspect.GetMonthlyIncome());
            Console.WriteLine("NetWorth: {0} ", suspect.GetNetWorth());
            Console.WriteLine("NetWorth2: {0} ", suspect.GetNetWorth2());

        }
    }
}
