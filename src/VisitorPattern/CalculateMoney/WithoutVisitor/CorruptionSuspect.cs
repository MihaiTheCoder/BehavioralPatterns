using System;
using System.Collections.Generic;

namespace VisitorPattern.CalculateMoney.WithoutVisitor
{
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

        public double GetNetWorth()
        {
            double netWorth = 0;
            foreach (var asset in Assets)
            {
                netWorth += asset.GetNetWorth();
            }
            return netWorth;
        }

        public double GetNetWorth2()
        {
            double netWorth = 0;
            foreach (var asset in Assets)
            {
                netWorth += asset.GetNetWorth2();
            }
            return netWorth;
        }

        public double GetMonthlyIncome()
        {
            double monthlyIncome = 0;
            foreach (var asset in Assets)
            {
                monthlyIncome += asset.GetMonthlyIncome();
            }
            return monthlyIncome;
        }
    }

    public interface IAsset
    {
        double GetNetWorth();

        double GetNetWorth2();

        double GetMonthlyIncome();
    }

    public class Job : IAsset
    {
        public double Salary { get; set; }

        public string JobTitle { get; set; }

        public DateTime StartDate { get; set; }

        public double GetNetWorth()
        {
            return 0;
        }

        public double GetNetWorth2()
        {
            return 0;
        }

        public double GetMonthlyIncome()
        {
            return Salary;
        }
    }

    public class MoneyBankAccount : IAsset
    {
        public double Ammount { get; set; }
        public double InterestPerMonth { get; set; }

        public string Bank { get; set; }

        public double GetNetWorth()
        {
            return Ammount;
        }

        public double GetNetWorth2()
        {
            return Ammount + 210;
        }

        public double GetMonthlyIncome()
        {
            return InterestPerMonth * Ammount;
        }
    }

    public class Valuable : IAsset
    {
        public double EstimatedValue { get; set; }

        public double InterestPerMonth { get; set; }

        public double GetMonthlyIncome()
        {
            return 0;
        }

        public double GetNetWorth()
        {
            return EstimatedValue;
        }

        public double GetNetWorth2()
        {
            return EstimatedValue;
        }
    }

    public class Clock : Valuable { }

    public class RealEstate : Valuable { }

    public class Art : Valuable { }

    public class Loan : IAsset
    {
        public double Owed { get; set; }

        public double MonthlyPayment { get; set; }

        public double GetNetWorth()
        {
            return -Owed;
        }

        public double GetNetWorth2()
        {
            return -(Owed + 215);
        }

        public double GetMonthlyIncome()
        {
            return -MonthlyPayment;
        }
    }
}
