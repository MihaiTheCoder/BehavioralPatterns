using System;

namespace TemplatePattern.GameExample
{
    public class GameExample
    {
        public static void Run()
        {
            Console.WriteLine("Basketball game:");

            Basketball b = new Basketball();
            b.Play();

            Console.WriteLine("Football game:");
            Football f = new Football();
            f.Play();
        }
    }
}
