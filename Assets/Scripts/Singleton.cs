using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    public abstract class Singleton<T> : MonoBehaviour
    {
        private static T _instance;
        public static T Instance => _instance;

        protected void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);   
        }
    }
}
