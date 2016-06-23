using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern.Employee
{
    /// <summary>
    /// Memento object
    /// </summary>
    public class EmployeeMemento
    {
        public string Name { get; private set; }
        public string Address { get; private set; }

        public EmployeeMemento(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
