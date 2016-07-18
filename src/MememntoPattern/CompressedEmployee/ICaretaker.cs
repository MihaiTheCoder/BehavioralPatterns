using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern.CompressedEmployee
{
    public interface ICaretaker<T>
    {
        void Save(T obj);

        void Revert(T obj);
    }
}
