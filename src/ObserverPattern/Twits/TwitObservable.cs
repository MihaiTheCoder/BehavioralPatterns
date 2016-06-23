using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObserverPattern.Twits
{
    /// <summary>
    /// Concrete observable
    /// </summary>
    public class TwitObservable : IObservable<Twit>
    {
        List<IObserver<Twit>> observers;
        public TwitObservable()
        {
            observers = new List<IObserver<Twit>>();
        }
        public IDisposable Subscribe(IObserver<Twit> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }

        public void AddTwit(Twit twit)
        {
            foreach (var observer in observers.Where(o => o != twit.Emiter))
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
            private List<IObserver<Twit>> _observers;
            private IObserver<Twit> _observer;

            public Unsubscriber(List<IObserver<Twit>> observers, IObserver<Twit> observer)
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
