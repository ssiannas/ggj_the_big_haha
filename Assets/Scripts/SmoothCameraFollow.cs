using System;
using UnityEngine;

namespace the_haha
{

    public class CameraFollow : MonoBehaviour
    {
        public Transform player;  // Reference to the player's transform
        private Vector3 _velocity = Vector3.zero;
        private Vector3 _offset = new Vector3(0, 7, -3);

        private void Awake()
        {
            transform.rotation = Quaternion.Euler(60, 0, 0);
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