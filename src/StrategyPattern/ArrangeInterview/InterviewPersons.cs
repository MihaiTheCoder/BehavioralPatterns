using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern.ArrangeInterview
{
    public class InterviewPersons
    {
        public static InterviewedPerson[] Get()
        {
            return new InterviewedPerson[] {
                new InterviewedPerson(Role.Designer, Experience.Junior, HiringType.Contractor),
                new InterviewedPerson(Role.Designer, Experience.Junior, HiringType.FullTime),
                new InterviewedPerson(Role.Designer, Experience.Junior, HiringType.PartTime),

                new InterviewedPerson(Role.Designer, Experience.Medium, HiringType.Contractor),
                new InterviewedPerson(Role.Designer, Experience.Medium, HiringType.FullTime),
                new InterviewedPerson(Role.Designer, Experience.Medium, HiringType.PartTime),

                new InterviewedPerson(Role.Designer, Experience.Senior, HiringType.Contractor),
                new InterviewedPerson(Role.Designer, Experience.Senior, HiringType.FullTime),
                new InterviewedPerson(Role.Designer, Experience.Senior, HiringType.PartTime),

                new InterviewedPerson(Role.Designer, Experience.RockStar, HiringType.Contractor),
                new InterviewedPerson(Role.Designer, Experience.RockStar, HiringType.FullTime),
                new InterviewedPerson(Role.Designer, Experience.RockStar, HiringType.PartTime),


                new InterviewedPerson(Role.Devloper, Experience.Junior, HiringType.Contractor),
                new InterviewedPerson(Role.Devloper, Experience.Junior, HiringType.FullTime),
                new InterviewedPerson(Role.Devloper, Experience.Junior, HiringType.PartTime),

                new InterviewedPerson(Role.Devloper, Experience.Medium, HiringType.Contractor),
                new InterviewedPerson(Role.Devloper, Experience.Medium, HiringType.FullTime),
                new InterviewedPerson(Role.Devloper, Experience.Medium, HiringType.PartTime),

                new InterviewedPerson(Role.Devloper, Experience.Senior, HiringType.Contractor),
                new InterviewedPerson(Role.Devloper, Experience.Senior, HiringType.FullTime),
                new InterviewedPerson(Role.Devloper, Experience.Senior, HiringType.PartTime),

                new InterviewedPerson(Role.Devloper, Experience.RockStar, HiringType.Contractor),
                new InterviewedPerson(Role.Devloper, Experience.RockStar, HiringType.FullTime),
                new InterviewedPerson(Role.Devloper, Experience.RockStar, HiringType.PartTime),


                new InterviewedPerson(Role.DevOp, Experience.Junior, HiringType.Contractor),
                new InterviewedPerson(Role.DevOp, Experience.Junior, HiringType.FullTime),
                new InterviewedPerson(Role.DevOp, Experience.Junior, HiringType.PartTime),

                new InterviewedPerson(Role.DevOp, Experience.Medium, HiringType.Contractor),
                new InterviewedPerson(Role.DevOp, Experience.Medium, HiringType.FullTime),
                new InterviewedPerson(Role.DevOp, Experience.Medium, HiringType.PartTime),

                new InterviewedPerson(Role.DevOp, Experience.Senior, HiringType.Contractor),
                new InterviewedPerson(Role.DevOp, Experience.Senior, HiringType.FullTime),
                new InterviewedPerson(Role.DevOp, Experience.Senior, HiringType.PartTime),

                new InterviewedPerson(Role.DevOp, Experience.RockStar, HiringType.Contractor),
                new InterviewedPerson(Role.DevOp, Experience.RockStar, HiringType.FullTime),
                new InterviewedPerson(Role.DevOp, Experience.RockStar, HiringType.PartTime),


                new InterviewedPerson(Role.Manager, Experience.Junior, HiringType.Contractor),
                new InterviewedPerson(Role.Manager, Experience.Junior, HiringType.FullTime),
                new InterviewedPerson(Role.Manager, Experience.Junior, HiringType.PartTime),

                new InterviewedPerson(Role.Manager, Experience.Medium, HiringType.Contractor),
                new InterviewedPerson(Role.Manager, Experience.Medium, HiringType.FullTime),
                new InterviewedPerson(Role.Manager, Experience.Medium, HiringType.PartTime),

                new InterviewedPerson(Role.Manager, Experience.Senior, HiringType.Contractor),
                new InterviewedPerson(Role.Manager, Experience.Senior, HiringType.FullTime),
                new InterviewedPerson(Role.Manager, Experience.Senior, HiringType.PartTime),

                new InterviewedPerson(Role.Manager, Experience.RockStar, HiringType.Contractor),
                new InterviewedPerson(Role.Manager, Experience.RockStar, HiringType.FullTime),
                new InterviewedPerson(Role.Manager, Experience.RockStar, HiringType.PartTime),


                new InterviewedPerson(Role.Tester, Experience.Junior, HiringType.Contractor),
                new InterviewedPerson(Role.Tester, Experience.Junior, HiringType.FullTime),
                new InterviewedPerson(Role.Tester, Experience.Junior, HiringType.PartTime),

                new InterviewedPerson(Role.Tester, Experience.Medium, HiringType.Contractor),
                new InterviewedPerson(Role.Tester, Experience.Medium, HiringType.FullTime),
                new InterviewedPerson(Role.Tester, Experience.Medium, HiringType.PartTime),

                new InterviewedPerson(Role.Tester, Experience.Senior, HiringType.Contractor),
                new InterviewedPerson(Role.Tester, Experience.Senior, HiringType.FullTime),
                new InterviewedPerson(Role.Tester, Experience.Senior, HiringType.PartTime),

                new InterviewedPerson(Role.Tester, Experience.RockStar, HiringType.Contractor),
                new InterviewedPerson(Role.Tester, Experience.RockStar, HiringType.FullTime),
                new InterviewedPerson(Role.Tester, Experience.RockStar, HiringType.PartTime)
            };

        }
    }

    public class InterviewedPerson
    {
        static int id = 0;
        public InterviewedPerson(Role role, Experience xp, HiringType hiringType)
        {
            Id = id++;
            Name = "Name" + Id;
            Role = role;
            Experience = xp;
            HiringType = hiringType;
            
        }
        public string Name { get; set; }

        public int Id { get; set; }

        public Role Role { get; set; }

        public Experience Experience { get; set; }

        public HiringType HiringType { get; set; }
    }

    public enum Role
    {
        Devloper,
        Designer,
        Tester,
        Manager,
        DevOp
    }

    public enum Experience
    {
        Junior,
        Medium,
        Senior,
        RockStar
    }

    public enum HiringType
    {
        Contractor,
        PartTime,
        FullTime
    }
}
