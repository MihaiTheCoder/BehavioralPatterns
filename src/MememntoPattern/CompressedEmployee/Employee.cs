using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern.CompressedEmployee
{
    /// <summary>
    /// Originator
    /// </summary>
    [ProtoContract]
    public class Employee
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public string Address { get; set; }

        public List<String> Phones { get; set; }

        public byte[] Save()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, this);
                return ms.ToArray();
            }            
        }

        public void Revert(byte[] memento)
        {
            Employee employee;
            using (MemoryStream ms = new MemoryStream(memento))
            {
                employee = Serializer.Deserialize<Employee>(ms);
            }

            Name = employee.Name;
            Address = employee.Address;
        }
    }
}
