using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    public class TrapGameObjectInteractions : MonoBehaviour
    {
        public TrapController TrapCtrl { get; set; }

        void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            var player = other.gameObject.GetComponent<PlayerController>();
            TrapCtrl.OnPlayerCollision(player);
        }
    }
}
