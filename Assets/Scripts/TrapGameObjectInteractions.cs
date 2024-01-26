using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    public class TrapGameObjectInteractions : MonoBehaviour
    {
        public int TrapDamage { get; set; }
        
        public TrapGameObjectInteractions(int trapDamage)
        {
            TrapDamage = trapDamage;
        }
        
        void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            var player = other.gameObject.GetComponent<PlayerController>();
            player.Damage(TrapDamage);
        }
    }
}
