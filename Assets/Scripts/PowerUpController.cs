using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

namespace the_haha
{
    public class PowerUpController : MonoBehaviour
    {
        [SerializeField, InspectorName("PowerUp Data")]
        private PowerUpData data;
        private bool _isPurchased = false;
        [SerializeField, InspectorName("Outline Material")]
        private Material _outlineMaterial;

        public GameObject FloatingTextPrefab;

        private void Awake()
        {
            for (var i = 0; i < gameObject.transform.childCount; i++)
            {
                var child = gameObject.transform.GetChild(i);
                var objectiveBehaviour = child.AddComponent<PowerUpBehaviour>();
                objectiveBehaviour.SetOutlineMaterial(_outlineMaterial);
                objectiveBehaviour.OnPlayerCollisionEnter += OnPlayerCollisionEnter;
                objectiveBehaviour.OnPlayerCollisionExit += OnPlayerCollisionExit;
            }
        }

        public PowerUpData GetPowerUpData() => data;

        private void OnPlayerCollisionEnter(PlayerController player)
        {
            // 1. Add to player objectives
            player.AddPowerUp(this);
        }

        private void OnPlayerCollisionExit(PlayerController player)
        {
            player.RemovePowerUp(this);
        }

        public void ActivatePowerUp(PlayerController player)
        {
            PowerUpType type = data.PowerUpType;
            switch (type)
            {
                case PowerUpType.SPEED:
                {
                    player.GetComponent<PlayerMovementController>().IncreaseSpeed();
                    break;
                }
                case PowerUpType.DECAY_DOWN:
                {
                    InterestMeterController.Instance.ReduceDecayRate();
                    break;
                }
                case PowerUpType.MONEY_UP:
                {
                    GameController.Instance.AddCurrencyPerTcik();
                    break;
                }
                case PowerUpType.DMG_DOWN:
                { 
                    player.GetComponent<PlayerController>().SetDamageCoef();
                    break;
                }
            }

            Destroy(gameObject);
        }
    }
}