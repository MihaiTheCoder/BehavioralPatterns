using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern.GroundAirTrafficControl
{
    public class Optional<T>
    {
        private Optional() { }
        
        public bool IsPresent { get; private set; }

        private T value;

        public T Value
        {
            get
            {
                if (!IsPresent)
                    throw new InvalidOperationException("Could not get value from empty");
                return value;
            }
            private set { this.value = value; }
        }

        public static Optional<T> Empty
        {
            get
            {
                return new Optional<T>() { IsPresent = false };
            }
        }

        public static Optional<T> Of(T value)
        {
            return new Optional<T>() { IsPresent = true, Value = value };
        }
    }
}
