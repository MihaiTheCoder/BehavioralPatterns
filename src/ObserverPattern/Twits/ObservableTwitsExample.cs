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

            TwitUser t100 = new TwitUser("t100", observable);
            TwitUser r2d2 = new TwitUser("R2-D2", observable);

            t100.Twit("El chupacapra - BOOM BOOM");

            r2d2.Twit("Vamos vamos mi amor");

            t100.Dispose();

            observable.ItsGoingHomeTime();            
        }
    }
}
