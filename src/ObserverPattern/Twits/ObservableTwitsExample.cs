using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObserverPattern.Twits
{
    public class ObservableTwitsExample
    {
        public void Run()
        {
            TwitObservable observable = new TwitObservable();

            TwitUser t100 = new TwitUser("t100");
            TwitUser r2d2 = new TwitUser("r2d2");
            
            var t100Subscription = observable.Subscribe(t100);
            var r2d2Subscription = observable.Subscribe(r2d2);

            observable.AddTwit("El chupacapra");

            t100Subscription.Dispose();

            observable.AddTwit("Vamos vamos mi amor");

            observable.ItsGoingHomeTime();

            
        }
    }
}
