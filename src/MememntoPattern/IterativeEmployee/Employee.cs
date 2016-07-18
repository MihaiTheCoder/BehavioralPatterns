using System.Collections.Generic;

namespace MememntoPattern.IterativeEmployee
{
    /// <summary>
    /// Originator
    /// </summary>
    public class Employee
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public List<string> Phones { get; set; }

        public EmployeeMemento Save()
        {
            return new EmployeeMemento(Name, Address);
        }

        public void Revert(EmployeeMemento memento)
        {
            Name = memento.Name;

            Address = memento.Address;
        }
    }
}
