using System;
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

        private void Awake()
        {
            Physics.gravity *= 2;
        }

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
            var velocity = moveSpeed * _direction;
            var rbVelocity = _rigidBody.velocity;
            _rigidBody.velocity = new Vector3(velocity.x, rbVelocity.y, velocity.z);
            
            if (_direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(_direction, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 500f);
            }
        }

    }

}
