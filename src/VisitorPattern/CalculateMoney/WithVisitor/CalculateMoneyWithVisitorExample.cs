using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorPattern.CalculateMoney.WithVisitor
{
    public class CalculateMoneyWithVisitorExample
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

            MonthlyIncomeVisitor mVisitor = new MonthlyIncomeVisitor();
            suspect.Accept(mVisitor);
            Console.WriteLine("Monthly income: {0} ", mVisitor.MonthlyIncome);

            NetWorthVisitor nVisitor = new NetWorthVisitor();
            suspect.Accept(nVisitor);
            Console.WriteLine("NetWorth: {0}", nVisitor.NetWorth);

            NetWorth2Visitor n2Visitor = new NetWorth2Visitor();
            suspect.Accept(n2Visitor);
            Console.WriteLine("NetWorth2: {0}", n2Visitor.NetWorth);
        }
    }
}
