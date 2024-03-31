
using System;

namespace VampireSurvivors.Lib.Basic.Completables
{

    public class Completable<T>
    {
        public Action Completed;
        public T Value;


        public Completable()
        {
        }

        public void Complete()
        {
            Completed?.Invoke();
        }
    }

}
