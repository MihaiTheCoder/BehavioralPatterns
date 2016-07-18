namespace MememntoPattern.IterativeEmployee
{
    /// <summary>
    /// Memento object
    /// </summary>
    public class EmployeeMemento : IIterativeMemento<EmployeeMemento, EmployeeMementoDiff>
    {
        public string Name { get; private set; }
        public string Address { get; private set; }

        public EmployeeMemento(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public EmployeeMementoDiff GetDiffFor(EmployeeMemento e)
        {
            EmployeeMementoDiff diff = new EmployeeMementoDiff();

            if (Name != e.Name)
                diff.UpdatedName = Name;

            if (Address != e.Address)
                diff.UpdatedAddress = Address;

            return diff;
        }

        public void UpdateWithDelta(EmployeeMementoDiff diff)
        {
            if (diff.UpdatedName != null)
                Name = diff.UpdatedName;

            if (diff.UpdatedAddress != null)
                Address = diff.UpdatedAddress;
        }

        public EmployeeMemento Clone()
        {
            return new EmployeeMemento(Name, Address);
        }        
    }

    public class EmployeeMementoDiff
    {
        public string UpdatedName { get; set; }

        public string UpdatedAddress { get; set; }
    }
}
