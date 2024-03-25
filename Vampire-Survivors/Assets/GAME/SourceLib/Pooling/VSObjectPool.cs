using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Lib.Pooling
{
    public class VSObjectPool<T> where T : Component
    {
        private List<T> _objectList = new List<T>() { };
                
        public bool TryRetrieve( out T a_objPool)
        {
            a_objPool = null;
            foreach (T obj in _objectList)
            {
                if (!obj.gameObject.activeInHierarchy)
                {
                    a_objPool = obj;
                    return true;
                }
            }
            return false;
        }


        public void Add(T a_obj)
        {
            _objectList.Add(a_obj);
        }
    }
}