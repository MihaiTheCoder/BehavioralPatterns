using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern.Employee
{
    /// <summary>
    /// Originator
    /// </summary>
    public class Employee
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public List<String> Phones { get; set; }

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
