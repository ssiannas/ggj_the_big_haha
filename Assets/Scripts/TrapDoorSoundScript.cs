using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    public class TrapDoorSoundScript : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            AudioManager.Instance.Play("FallingSound");
        }
    }
}
