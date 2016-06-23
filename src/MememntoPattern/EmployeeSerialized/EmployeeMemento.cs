using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern.EmployeeSerialized
{
    /// <summary>
    /// Memento object
    /// </summary>
    public class EmployeeMemento
    {
        public string SerializedEmployee;

        public EmployeeMemento(string serializedEmployee)
        {
            SerializedEmployee = serializedEmployee;
        }
    }
}
