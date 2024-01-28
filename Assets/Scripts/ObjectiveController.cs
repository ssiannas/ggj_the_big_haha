using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace the_haha
{
    public class ObjectiveController : MonoBehaviour
    {
        [SerializeField, InspectorName("Objective Data")]
        private ObjectiveData data;
        private bool _isCompleted = false;
        [SerializeField, InspectorName("Outline Material")]
        private Material _outlineMaterial;
        
        private void Awake()
        {
            for (var i = 0; i < gameObject.transform.childCount; i++)
            {
                var child = gameObject.transform.GetChild(i);
                var objectiveBehaviour = child.AddComponent<ObjectiveBehaviour>();
                objectiveBehaviour.SetOutlineMaterial(_outlineMaterial);
                objectiveBehaviour.OnPlayerCollisionEnter += OnPlayerCollisionEnter;
                objectiveBehaviour.OnPlayerCollisionExit += OnPlayerCollisionExit;
            }
        }

        public ObjectiveData GetObjectiveData() => data;
        private void OnPlayerCollisionEnter(PlayerController player)
        {
            // 1. Add to player objectives
            player.AddObjective(this);
        }

        private void OnPlayerCollisionExit(PlayerController player)
        {
            player.RemoveObjective(this);
        }
        
        public void CompleteObjective()
        {
            if (_isCompleted) return;
            _isCompleted = true;
            InterestMeterController.Instance.IncrementInterestLevelByAmount(data.amusement);
            SmartDialogue.Instance.AddLines(data.dialogue.ToList());
            SmartDialogue.Instance.StartDialogue();
        }
    }
}
