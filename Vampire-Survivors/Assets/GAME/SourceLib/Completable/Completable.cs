using System;
using UnityEngine;
namespace VampireSurvivors.Lib.Basic.Completables
{
    /// <summary>
    /// Notifier for some value completed
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Completable<T> : ICompletable<T>
    {
        private Action _completed;
        public T Value { get; set; }
        private bool _isCompleted = false;


        public Completable()
        {
        }


        public void Complete()
        {
            if (!_isCompleted)
            {
                _isCompleted = true;
                _completed?.Invoke();
            }
            else
            {
                Debug.LogError("This Completable has been already completed!");
            }
        }


        public void RunOnCompleted(Action a_void)
        {
            _completed += a_void;
        }
    }

}
