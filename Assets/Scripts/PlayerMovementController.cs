using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace the_haha
{
    public class PlayerMovementController : MonoBehaviour
    {
        
        enum PlayerState
        {
            Idle,
            Walking,
            Dead
        }
        
        public InputAction moveAction;
        [SerializeField]
        private float moveSpeed = 5.0f;
        private Rigidbody _rigidBody;
        private Vector3 _direction;

        private Animator _animator;

        private bool IsWalking
        {
            set
            {
                if (value)
                {
                    HandleWalkingState();
                }
                else
                {
                    HandleIdleState();
                }
            }
        }
        private PlayerState _playerState; 
        
        void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _playerState = PlayerState.Idle;
        }

        private void HandleWalkingState()
        {
            if (_playerState == PlayerState.Walking) return;
            _animator.SetBool("isWalking", true);
            _playerState = PlayerState.Walking;
        }
        
        private void HandleIdleState()
        {
            if (_playerState == PlayerState.Idle) return;
            _animator.SetBool("isWalking", false);
            _playerState = PlayerState.Idle;
        }
        
        void OnMove(InputValue pos)
        {
           
            Vector2 inputPos = pos.Get<Vector2>();
            
            IsWalking = inputPos != Vector2.zero;
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
