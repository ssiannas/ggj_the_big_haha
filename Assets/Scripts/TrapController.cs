using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    public class TrapController : MonoBehaviour
    {
        public TrapData trapData;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {   
                //Do something with the player object.
            }
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
