using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VampireSurvivors.Lib.Basic.Completables
{

    public interface ICompletable<T>
    {
        
        public T Value { get; }

        public void RunOnCompleted(Action a_void);
    }
}