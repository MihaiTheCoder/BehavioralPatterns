using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObserverPattern.Twits
{
    /// <summary>
    /// Concrete observer
    /// </summary>
    public class TwitUser : IObserver<Twit>, IDisposable
    {
        TwitObservable twits;
        public string Name { get; private set; }
        IDisposable channel;
        public TwitUser(string name, TwitObservable twits)
        {
            this.Name = name;
            channel = twits.Subscribe(this);
            this.twits = twits;
        }

        public void Twit(string twit)
        {
            twits.AddTwit(new Twit { Emiter = this, Message = twit });
        }
        public void OnCompleted()
        {
            Console.WriteLine("{0} finished watching twitter", Name);
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Error while watching twitter: {0}", error);
        }

        public void OnNext(Twit value)
        {
            Console.WriteLine("{0} just observed that {1} tweeted {2}", Name, value.Emiter.Name, value.Message);
        }

        public void Dispose()
        {
            channel.Dispose();
        }
    }
}
