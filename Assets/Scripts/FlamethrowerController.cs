using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    public class FlamethrowerController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem flameParticles;
        private BoxCollider flameCollider;

        // Start is called before the first frame update
        void Awake()
        {
            flameCollider = GetComponent<BoxCollider>();
        }

        // Update is called once per frame
        void Update()
        {
            // if (Input.GetKeyDown(KeyCode.A))
            // {
            //     SetFlameActive(false);
            // }
            //
            // if (Input.GetKeyDown(KeyCode.S))
            // {
            //     SetFlameActive(true);
            // }
        }

        public void SetFlameActive(bool active)
        {
            if (active)
            {
                // flameParticles.SetActive(true);
                flameParticles.enableEmission = true;
                flameCollider.enabled = true;
            }
            else
            {
                flameParticles.enableEmission = false;
                flameCollider.enabled = false;
            }
        }
    }
}