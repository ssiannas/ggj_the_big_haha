using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

namespace the_haha
{
    [RequireComponent(typeof(PlayerMovementController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField, InspectorName("Hit Points")]
        private int hitPoints = 3;
        private List<ObjectiveController> _objectives;
        public InputAction actionAction;
        
        void Start()
        {
            _objectives = new List<ObjectiveController>();
        }
        
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

        public void AddObjective(ObjectiveController objective)
        {
            _objectives.Add(objective);
        }
        
        public void RemoveObjective(ObjectiveController objective)
        {
            _objectives.Remove(objective);
        }
        
        private void ActionPressed()
        {
            foreach (var objective in _objectives)
            {
                objective.CompleteObjective();
            }
        }
        
        private void OnFire(InputValue value)
        { 
            ActionPressed();
        }
    }
}
