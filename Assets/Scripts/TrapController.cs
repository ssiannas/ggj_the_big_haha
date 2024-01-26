using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    public class TrapController : MonoBehaviour
    {
        public TrapData trapData;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var player = other.GetComponent<PlayerController>();
                player.Damage(trapData.damage);
            }
        }
    }
}
