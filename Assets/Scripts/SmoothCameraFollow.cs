using UnityEngine;

namespace the_haha
{

    public class CameraFollow : MonoBehaviour
    {
        public Transform player;  // Reference to the player's transform
        private Vector3 _velocity = Vector3.zero;
        
        void LateUpdate()
        {
            if (!player) return;
            Vector3 desiredPosition = player.position;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
        }
    }

}