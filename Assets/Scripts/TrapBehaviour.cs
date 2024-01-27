using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    public class TrapBehaviour : MonoBehaviour
    {
        public delegate void PlayerColisionDelegate (PlayerController player);
        public event PlayerColisionDelegate OnPlayerCollisionEnter;
        
        void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            var player = other.gameObject.GetComponent<PlayerController>();
            OnPlayerCollisionEnter?.Invoke(player);
        }
    }
}
