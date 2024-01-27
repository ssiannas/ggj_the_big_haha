using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    public class TrapdoorController : MonoBehaviour
    {
        Animator animator;

        // Start is called before the first frame update
        void Awake()
        {
            animator = GetComponent<Animator>();
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

        public void PlayClosedAnimation()
        {
            animator.Play("Trapdoor_Closed");
        }

        public void PlayCrumblingAnimation()
        {
            animator.Play("Trapdoor_Crumbling");
        }

        public void PlayOpenAnimation()
        {
            animator.Play("Trapdoor_Open");
        }
    }
}