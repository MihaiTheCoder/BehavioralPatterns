using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObserverPattern.Twits
{
    /// <summary>
    /// Concrete observer
    /// </summary>
    public class TwitUser : IObserver<string>
    {
        string name;
        public TwitUser(string name)
        {
            this.name = name;
        }
        public void OnCompleted()
        {
            Console.WriteLine("{0} finished watching twitter", name);
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Error while watching twitter: {0}", error);
        }

        public void OnNext(string value)
        {
            Console.WriteLine("{0} just observed that something {1} was tweeted", name, value);
        }
    }
}
