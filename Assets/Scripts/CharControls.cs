using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace the_haha
{
    public class CharControls : MonoBehaviour
    {
        
        public InputAction moveAction;
        [SerializeField]
        private float moveSpeed = 5.0f;
        public int hp = 3;

        public Rigidbody rb;

        Vector3 direction;


        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void OnMove(InputValue pos)
        {
            Vector2 inputPos = pos.Get<Vector2>();
            //Vector3 playerPos = transform.position;
            direction.x = inputPos.x;
            direction.z = inputPos.y;
            direction.Normalize();
            //rb.velocity += playerPos;

        }


        void Update()
        {
            //moveAction.Enable();
        }

        private void FixedUpdate()
        {
            direction.y = rb.velocity.y/moveSpeed;
            rb.velocity = moveSpeed * direction;
        }

    }

}
