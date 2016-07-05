using IteratorPattern.FileExample;
using IteratorPattern.TVExample.TVEnumerable;
using IteratorPattern.TvIterator;
using System;

namespace IteratorPattern
{
    public class IteratorPatternExamples
    {
        public static void Run()
        {
            Console.WriteLine(GetPatternDescription());
            Console.WriteLine(GetActors());
            GoToNextStep();

            TVIteratorExample tvIteratorExample = new TVIteratorExample();
            tvIteratorExample.Run();

            TVEnumerableExample tvEnumerableExample = new TVEnumerableExample();
            tvEnumerableExample.Run();

            ReadBigFilesExample bigFileExample = new ReadBigFilesExample();
            bigFileExample.Run();

            //Iterator that selects in batches
        }

        public static string GetPatternDescription()
        {
            return @"Pattern description:
In object-oriented programming, the iterator pattern is a design pattern in which an iterator 
is used to traverse a container and access the container's elements.
C# interfaces helpers for Iterator pattern: IEnumerator<T>, IEnumerable<T>, yield for creating IEnumerable<T>
Java: Iterator<E>, Iterable<E>";
        }

        public static string GetActors()
        {
            return @"Actors:
Iterator: interface with hasNext/next/current methods or variantions from this
Concrete interator: concrete class that implements Iterator
Aggregate: interface for returning the iterator
Concrete aggregate: imlpementation of aggregate";
        }

        private static void GoToNextStep()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
