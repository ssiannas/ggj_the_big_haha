using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    public class ObjectiveBehaviour : MonoBehaviour
    {
        public delegate void PlayerCollisionDelegate (PlayerController player);
        public event PlayerCollisionDelegate OnPlayerCollisionEnter;
        public event PlayerCollisionDelegate OnPlayerCollisionExit;
        
        
        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            var player = other.gameObject.GetComponent<PlayerController>();
            OnPlayerCollisionEnter?.Invoke(player);
            
            // enable object outline
        }

        private void OnCollisionExit(Collision other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            var player = other.gameObject.GetComponent<PlayerController>();
            OnPlayerCollisionExit?.Invoke(player);
            
            // disable object outline
        }
    }
}
