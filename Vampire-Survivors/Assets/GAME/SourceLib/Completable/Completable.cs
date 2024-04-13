
using System;

namespace VampireSurvivors.Lib.Basic.Completables
{

    public class Completable<T>: ICompletable<T>
    {
        private Action _completed;
        public T Value { get;  set; }


        public Completable()
        {
        }
         

        public void Complete()
        {
            _completed?.Invoke();
        }

        public void RunOnCompleted(Action a_void)
        {
            _completed += a_void;
        }
    }

}
