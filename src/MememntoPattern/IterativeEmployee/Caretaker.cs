using System.Collections.Generic;

namespace MememntoPattern.IterativeEmployee
{
    /// <summary>
    /// Caretaker
    /// </summary>
    public class Caretaker
    {
        EmployeeMemento initialMememento;
        List<EmployeeMementoDiff> diffs;

        public Caretaker()
        {
            diffs = new List<EmployeeMementoDiff>();
            initialMememento = null;
        }

        public void Save(Employee emp)
        {
            EmployeeMemento memento = emp.Save();

            if (initialMememento == null)
                initialMememento = memento;
            else            
                diffs.Add(memento.GetDiffFor(GetLastSavedVersion()));            
        }        

        public void Revert(Employee emp)
        {
            EmployeeMemento em = GetLastSavedVersion();

            if (diffs.Count > 0)
                diffs.RemoveAt(diffs.Count - 1);

            emp.Revert(em);
        }

        private EmployeeMemento GetLastSavedVersion()
        {
            var memento = initialMememento.Clone();
            foreach (var diff in diffs)
            {
                memento.UpdateWithDelta(diff);
            }

            return memento;
        }
    }
}
