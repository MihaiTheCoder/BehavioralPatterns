using IteratorPattern.FileExample;
using IteratorPattern.TVExample.TVEnumerable;
using IteratorPattern.TvIterator;

namespace IteratorPattern
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class IteratorPatternExamples
    {
        public static void Run()
        {
            TVIteratorExample tvIteratorExample = new TVIteratorExample();
            tvIteratorExample.Run();

            TVEnumerableExample tvEnumerableExample = new TVEnumerableExample();
            tvEnumerableExample.Run();

            ReadBigFilesExample bigFileExample = new ReadBigFilesExample();
            bigFileExample.Run();

            //Iterator that selects in batches
        }
    }
}
