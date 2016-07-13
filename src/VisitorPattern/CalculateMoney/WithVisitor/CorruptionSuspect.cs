using System;
using System.Collections.Generic;

namespace VisitorPattern.CalculateMoney.WithVisitor
{
    /// <summary>
    /// ObjectStructure
    /// </summary>
    public class CorruptionSuspect : IAsset
    {
        public CorruptionSuspect()
        {
            MoneyBankAccounts = new List<MoneyBankAccount>();
            Valuables = new List<Valuable>();
            Loans = new List<Loan>();
            Jobs = new List<Job>();

        }
        public List<MoneyBankAccount> MoneyBankAccounts { get; set; }

        public List<Valuable> Valuables { get; set; }

        public List<Loan> Loans { get; set; }

        public List<Job> Jobs { get; set; }

        public List<IAsset> Assets
        {
            get
            {
                List<IAsset> assets = new List<IAsset>();
                assets.AddRange(MoneyBankAccounts);
                assets.AddRange(Valuables);
                assets.AddRange(Loans);
                assets.AddRange(Jobs);
                return assets;
            }
        }

        public void Accept(IVisitor visitor)
        {            
            foreach (var asset in Assets)
            {
                asset.Accept(visitor);
            }            
        }
    }


    /// <summary>
    /// Visitable
    /// </summary>
    public interface IAsset
    {
        void Accept(IVisitor visitor);
    }

    /// <summary>
    /// Concrete Visitable
    /// </summary>
    public class Job : IAsset
    {
        public double Salary { get; set; }

        public string JobTitle { get; set; }

        public DateTime StartDate { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// Concrete Visitable
    /// </summary>
    public class MoneyBankAccount : IAsset
    {
        public double Ammount { get; set; }
        public double InterestPerMonth { get; set; }

        public string Bank { get; set; }

        public double GetNetWorth()
        {
            return Ammount;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// Concrete Visitable
    /// </summary>
    public class Valuable : IAsset
    {
        public double EstimatedValue { get; set; }

        public double InterestPerMonth { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// Concrete Visitable
    /// </summary>
    public class Clock : Valuable { }

    /// <summary>
    /// Concrete Visitable
    /// </summary>
    public class RealEstate : Valuable { }

    /// <summary>
    /// Concrete Visitable
    /// </summary>
    public class Art : Valuable { }

    /// <summary>
    /// Concrete Visitable
    /// </summary>
    public class Loan : IAsset
    {
        public double Owed { get; set; }

        public double MonthlyPayment { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
