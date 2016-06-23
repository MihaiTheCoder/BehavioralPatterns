using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern.EmployeeSerialized
{
    /// <summary>
    /// Caretaker
    /// </summary>
    public class Caretaker
    {
        private LimitedSizeStack<EmployeeMemento> employeeHistory;

        public Caretaker()
        {
            employeeHistory = new LimitedSizeStack<EmployeeMemento>(10);
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
