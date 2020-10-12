using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.BaseLib
{
    public abstract class Subject
    {

        private static List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void DeleteObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            for(int i = 0; i < observers.Count; ++i)
            {
                observers[i].UpdateView();
            }
        }

    }
}
