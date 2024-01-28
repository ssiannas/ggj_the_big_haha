using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    public class FlamethrowerController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem flameParticles;
        private BoxCollider flameCollider;
        [SerializeField] private float toggleInterval = 1f;
        [SerializeField] private float flameDurationSec = 1f;
        private float _currentToggleTimer = 0f;
        [SerializeField] private float damageInterval = 1;
        private float _currentTimer = 0f;
        private int _damage;
        private int _amusement;
        private bool _isActive = false;
        [SerializeField] 
        // Start is called before the first frame update
        void Awake()
        {
            flameCollider = GetComponent<BoxCollider>();
            _damage = GetComponentInParent<TrapController>().trapData.damage;
            _amusement = GetComponentInParent<TrapController>().trapData.amusement;
            SetFlameActive(_isActive);
        }

        // Update is called once per frame
        void Update()
        {
            _currentToggleTimer += Time.deltaTime;
            if (_currentToggleTimer >= toggleInterval && !_isActive)
            {
                SetFlameActive(true);
                _currentToggleTimer = 0f;
            }
            else if (_currentToggleTimer >= flameDurationSec && _isActive)
            {
                SetFlameActive(false);
                _currentToggleTimer = 0f;
            }
            
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
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            var player = other.gameObject.GetComponent<PlayerController>();
            player.Damage(_damage);
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            _currentTimer += Time.fixedDeltaTime;
            if (_currentTimer >= damageInterval)
            {
                var player = other.gameObject.GetComponent<PlayerController>();
                player.Damage(_damage);
                InterestMeterController.Instance.IncrementInterestLevelByAmount(_amusement);
                _currentTimer = 0f;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            _currentTimer = 0f;
        }

        public void SetFlameActive(bool active)
        {
            _isActive = active;
            if (active)
            {
                // flameParticles.SetActive(true);
                flameParticles.enableEmission = true;
                flameCollider.enabled = true;
                _currentTimer = 0f;
            }
            else
            {
                flameParticles.enableEmission = false;
                flameCollider.enabled = false;
            }
        }
    }
}