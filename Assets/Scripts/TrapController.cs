using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace the_haha
{
    public class TrapController : MonoBehaviour
    {
        public TrapData trapData;

        void Awake()
        {
            for (var i = 0 ; i < gameObject.transform.childCount; i++)
            {
                var child = gameObject.transform.GetChild(i);
                child.AddComponent<TrapGameObjectInteractions>().TrapDamage = trapData.damage;
            }
        }
    }
}
