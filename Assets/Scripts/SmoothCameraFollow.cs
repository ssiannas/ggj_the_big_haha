using System;
using UnityEngine;

namespace the_haha
{

    public class CameraFollow : MonoBehaviour
    {
        public Transform player;  // Reference to the player's transform
        private Vector3 _offset = new Vector3(0, 7, -3);
        private Quaternion _originalRotation;

        private void Awake()
        {
            transform.rotation = Quaternion.Euler(60, 0, 0);
        }
        
        public void SetTarget(GameObject target)
        {
            player = target.transform;
            var cameraTransform = transform;
            // match target looking direction
            var playerDirection = player.TransformDirection(player.forward);
            var desiredDirection = new Vector3(playerDirection.x, 0, playerDirection.z);
            _offset = playerDirection * -3;
            _offset.y = 7;
            var rotation = cameraTransform.rotation;
            rotation = Quaternion.LookRotation(desiredDirection);
            // rotate by 60 degrees
            rotation *= Quaternion.Euler(60, 0, 0);
            cameraTransform.rotation = rotation;
        }
        
        void LateUpdate()
        {
            if (!player) return;
            var pos = player.position;
            Vector3 desiredPosition = new Vector3(pos.x + _offset.x, _offset.y, pos.z + _offset.z);
            transform.position = desiredPosition;
        }
    }

}