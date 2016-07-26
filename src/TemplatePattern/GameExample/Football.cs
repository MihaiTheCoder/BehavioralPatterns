using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePattern.GameExample
{
    /// <summary>
    /// Concrete class
    /// </summary>
    public class Football : Game
    {
        protected override void EndGame()
        {
            Console.WriteLine("90 minutes over, game ended");
        }

        protected override void InitGame()
        {
            Console.WriteLine("Let the players get on the field with their kids");
        }

        protected override void StartGame()
        {
            Console.WriteLine("Let le ball in le goal");
        }
    }
}
