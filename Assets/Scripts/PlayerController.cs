using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace the_haha
{
    [RequireComponent(typeof(PlayerMovementController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField, InspectorName("Hit Points")]
        private int hitPoints = 3;

        public void Damage(int amount = 1)
        {
            hitPoints -= amount;
            if (hitPoints <= 0)
            {
                OnDeath();
            }
        }
        
        private void OnDeath() 
        {
            GameController.Instance.GameOver();
        }
    }
}
