using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern.EmployeeSerialized
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
            return new EmployeeMemento(JsonConvert.SerializeObject(this));
        }

        public void Revert(EmployeeMemento memento)
        {
            Employee newEmployee = JsonConvert.DeserializeObject<Employee>(memento.SerializedEmployee);
            Name = newEmployee.Name;
            Address = newEmployee.Address;
            Phones = newEmployee.Phones;
        }
    }
}
