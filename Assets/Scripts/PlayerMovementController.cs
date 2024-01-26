using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace the_haha
{
    public class PlayerMovementController : MonoBehaviour
    {
        
        public InputAction moveAction;
        [SerializeField]
        private float moveSpeed = 5.0f;
        private Rigidbody _rigidBody;
        private Vector3 _direction;


        void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        void OnMove(InputValue pos)
        {
            Vector2 inputPos = pos.Get<Vector2>();
            //Vector3 playerPos = transform.position;
            _direction.x = inputPos.x;
            _direction.z = inputPos.y;
            _direction.Normalize();
            //_rigidBody.velocity += playerPos;
        }

        private void FixedUpdate()
        {
            _direction.y = _rigidBody.velocity.y/moveSpeed;
            _rigidBody.velocity = moveSpeed * _direction;
        }

    }

}
