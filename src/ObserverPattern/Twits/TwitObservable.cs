using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObserverPattern.Twits
{
    /// <summary>
    /// Concrete observable
    /// </summary>
    public class TwitObservable : IObservable<string>
    {
        List<IObserver<string>> observers;
        public TwitObservable()
        {
            observers = new List<IObserver<string>>();
        }
        public IDisposable Subscribe(IObserver<string> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }

        public void AddTwit(string twit)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(twit);
            }
        }   
        
        public void ItsGoingHomeTime()
        {
            foreach (var observer in observers)
            {
                observer.OnCompleted();
            }
        }     

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<string>> _observers;
            private IObserver<string> _observer;

            public Unsubscriber(List<IObserver<string>> observers, IObserver<string> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }
    }


}
