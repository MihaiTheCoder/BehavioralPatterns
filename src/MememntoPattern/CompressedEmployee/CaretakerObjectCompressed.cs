using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace MememntoPattern.CompressedEmployee
{
    /// <summary>
    /// Caretaker
    /// </summary>
    public class CaretakerObjectCompressed : ICaretaker<Employee>
    {
        private Stack<byte[]> employeeHistory;

        public CaretakerObjectCompressed()
        {
            employeeHistory = new Stack<byte[]>();
        }

        public void Save(Employee emp)
        {
            employeeHistory.Push(ByteArrayCompressionUtility.Compress(emp.Save()));
        }      

        public void Revert(Employee emp)
        {
            if (employeeHistory.Count > 0)
                emp.Revert(ByteArrayCompressionUtility.Decompress(employeeHistory.Pop()));
        }
    }    
}
