using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePattern.GameExample
{
    public class Basketball : Game
    {
        protected override void EndGame()
        {
            Console.WriteLine("Good basketball game, GG");
        }

        protected override void InitGame()
        {
            Console.WriteLine("Le players are warming up, shooting at the goal");
        }

        protected override void StartGame()
        {
            Console.WriteLine("Let le basket game, start");
        }
    }
}
