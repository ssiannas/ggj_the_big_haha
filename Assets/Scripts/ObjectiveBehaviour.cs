using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace the_haha
{
    public class ObjectiveBehaviour : MonoBehaviour
    {
        public delegate void PlayerCollisionDelegate (PlayerController player);
        public event PlayerCollisionDelegate OnPlayerCollisionEnter;
        public event PlayerCollisionDelegate OnPlayerCollisionExit;

        private Material _outlineMaterial;
        private List<Material> _originalMaterials;

        private void Awake()
        {
            _originalMaterials = new List<Material>(GetComponent<MeshRenderer>().materials);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            var player = other.gameObject.GetComponent<PlayerController>();
            OnPlayerCollisionEnter?.Invoke(player);
            
            // enable object outline
            if (!(_outlineMaterial != null)) return;
            var meshRenderer = GetComponent<MeshRenderer>();
            var newMaterials = new List<Material>(_originalMaterials);
            newMaterials.Add(_outlineMaterial);
            meshRenderer.materials = newMaterials.ToArray();
        }

        private void OnCollisionExit(Collision other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            var player = other.gameObject.GetComponent<PlayerController>();
            OnPlayerCollisionExit?.Invoke(player);
            
            // disable object outline
            if (!(_outlineMaterial != null)) return;
            var meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.materials = _originalMaterials.ToArray();
        }
        
        public void SetOutlineMaterial(Material outlineMaterial)
        {
            _outlineMaterial = outlineMaterial;
        }
    }
}
