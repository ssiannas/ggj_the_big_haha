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
        private bool _isCompleted = false;
        [SerializeField, InspectorName("Outline Material")]
        private Material _outlineMaterial;

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
           // player.AddPowerUp(this);
        }

        private void OnPlayerCollisionExit(PlayerController player)
        {
           // player.RemovePowerUp(this);
        }

        public void CompleteObjective()
        {
            if (_isCompleted) return;
            _isCompleted = true;
            //InterestMeterController.Instance.IncrementInterestLevelByAmount(data.amusement);
            //Debug.Log(data.dialogue);
            //SmartDialogue.Instance.lines[0] = data.dialogue;
            //SmartDialogue.Instance.StartDialogue();
        }
    }
}
