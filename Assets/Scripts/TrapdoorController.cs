using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    public class TrapdoorController : MonoBehaviour
    {
        private Animator _animator;
        private float _timeToOpen = 1;
        private float _trapTimer = 0; 

        // Start is called before the first frame update
        void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            // if (Input.GetKeyDown(KeyCode.Q))
            // {
            //     PlayClosedAnimation();
            // }
            //
            // if (Input.GetKeyDown(KeyCode.W))
            // {
            //     PlayCrumblingAnimation();
            // }
            //
            // if (Input.GetKeyDown(KeyCode.E))
            // {
            //     PlayOpenAnimation();
            // }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            PlayCrumblingAnimation();    
        }

        private void OnCollisionStay(Collision other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            _trapTimer += Time.deltaTime;
            if (_trapTimer >= _timeToOpen)
            {
                PlayOpenAnimation();
            }
        }
        
        private void OnCollisionExit(Collision other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            if (_trapTimer < _timeToOpen)
            {
                PlayClosedAnimation();
            }
        }

        public void PlayClosedAnimation()
        {
            _animator.Play("Trapdoor_Closed");
        }

        public void PlayCrumblingAnimation()
        {
            _animator.Play("Trapdoor_Crumbling");
        }

        public void PlayOpenAnimation()
        {
            _animator.Play("Trapdoor_Open");
        }
    }
}