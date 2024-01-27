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
                
                child.AddComponent<TrapBehaviour>().OnPlayerCollisionEnter += OnPlayerCollision;
            }
        }
        
        private void OnPlayerCollision(PlayerController player)
        {
            player.Damage(trapData.damage);
            InterestMeterController.Instance.IncrementInterestLevelByAmount(trapData.amusement);
        }
    }
}
