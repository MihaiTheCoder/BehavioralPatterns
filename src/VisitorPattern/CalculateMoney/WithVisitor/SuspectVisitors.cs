using System;

namespace VisitorPattern.CalculateMoney.WithVisitor
{
    public interface IVisitor
    {
        void Visit(MoneyBankAccount moneyBankAccount);
        void Visit(Loan loan);
        void Visit(Job job);

        void Visit(Valuable valuable);        
    }

    public class NetWorthVisitor : IVisitor
    {
        public double NetWorth { get; private set; }

        public void Visit(Job job)
        {
            
        }

        public void Visit(Valuable valuable)
        {
            NetWorth += valuable.EstimatedValue;
        }

        public void Visit(Loan loan)
        {
            NetWorth -= loan.Owed;
        }

        public void Visit(MoneyBankAccount moneyBankAccount)
        {
            NetWorth += moneyBankAccount.Ammount;
        }
    }

    public class NetWorth2Visitor : IVisitor
    {
        public double NetWorth { get; private set; }

        public void Visit(Job job)
        {
            
        }

        public void Visit(Valuable valuable)
        {
            NetWorth += valuable.EstimatedValue;
        }

        public void Visit(Loan loan)
        {
            NetWorth -= loan.Owed + 215;
        }

        public void Visit(MoneyBankAccount moneyBankAccount)
        {
            NetWorth += moneyBankAccount.Ammount + 210;
        }
    }

    public class MonthlyIncomeVisitor : IVisitor
    {
        public double MonthlyIncome { get; private set; }
        public void Visit(Job job)
        {
            MonthlyIncome += job.Salary;
        }

        public void Visit(Valuable valuable)
        {
            
        }

        public void Visit(Loan loan)
        {
            MonthlyIncome -= loan.MonthlyPayment;
        }

        public void Visit(MoneyBankAccount moneyBankAccount)
        {
            MonthlyIncome += moneyBankAccount.InterestPerMonth * moneyBankAccount.Ammount;
        }
    }
}
