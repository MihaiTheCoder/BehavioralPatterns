using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern.Employee
{
    /// <summary>
    /// Caretaker
    /// </summary>
    public class Caretaker
    {
        private Stack<EmployeeMemento> employeeHistory;

        public Caretaker()
        {
            employeeHistory = new Stack<EmployeeMemento>();
        }

        public void Save(Employee emp)
        {
            employeeHistory.Push(emp.Save());
        }

        public void Revert(Employee emp)
        {
            emp.Revert(employeeHistory.Pop());
        }
    }
}
