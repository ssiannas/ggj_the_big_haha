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
        private float hitPoints = 100.0f;
        private float MAX_HP;
        private float damagecoef = 1.0f;
        private List<ObjectiveController> _objectives;
        private List<PowerUpController> _powerups;
        public InputAction actionAction;

        void Start()
        {
            _objectives = new List<ObjectiveController>();
            _powerups = new List<PowerUpController>();
            MAX_HP = hitPoints;
        }

        public void Damage(int amount = 1)
        {
            hitPoints -= amount * damagecoef;

            var interestMeter = GameObject.FindWithTag("HP");
            interestMeter.GetComponent<ProgressBar>().SetProgress(hitPoints / MAX_HP);

            if (hitPoints <= 0)
            {
                OnDeath();
            }
        }

        private void OnDeath()
        {
            Destroy(gameObject);
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

        public void AddPowerUp(PowerUpController powerUp)
        {
            _powerups.Add(powerUp);
        }

        public void RemovePowerUp(PowerUpController powerUp)
        {
            _powerups.Remove(powerUp);
        }

        private void ActionPressed()
        {
            foreach (var objective in _objectives)
            {
                objective.CompleteObjective();
            }
            foreach (var powerup in _powerups)
            {

                var coins = GameController.Instance.GetCoins();
                if (coins >= powerup.GetPowerUpData().cost)
                {
                    GameController.Instance.SetCoins(coins - powerup.GetPowerUpData().cost);
                    powerup.ActivatePowerUp(this);
                }             
            }
        }

        private void OnFire(InputValue value)
        {
            ActionPressed();
        }

        public void SetDamageCoef()
        {
            damagecoef *= 0.75f;
        }
    }
}
