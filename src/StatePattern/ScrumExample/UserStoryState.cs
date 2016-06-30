using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatePattern.ScrumExample
{
    public enum UserStoryState
    {
        New = 0, Active = 1, Resolved = 2, Closed = 3, Removed = 4
    }
}
