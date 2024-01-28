using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace the_haha
{
    public class PowerUpBehaviour : MonoBehaviour
    {
        public delegate void PlayerCollisionDelegate(PlayerController player);

        public event PlayerCollisionDelegate OnPlayerCollisionEnter;
        public event PlayerCollisionDelegate OnPlayerCollisionExit;

        private Material _outlineMaterial;
        private List<Material> _originalMaterials;

        private GameObject FloatingText;
        private GameObject label;

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

            //show floating box
            var pupController = GetComponentInParent<PowerUpController>();
            FloatingText = pupController.FloatingTextPrefab;
            label = Instantiate(FloatingText, (transform.position + new Vector3(0, 1.5f, 0)),
                Quaternion.LookRotation(Camera.main.transform.forward), transform);

            label.GetComponent<TextMeshPro>().text =
                $"{pupController.GetPowerUpData().powerUpName}\nCost: {pupController.GetPowerUpData().cost}\nPress 'E'";
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
            //disable floating box
            if (label != null) Destroy(label);
        }

        public void SetOutlineMaterial(Material outlineMaterial)
        {
            _outlineMaterial = outlineMaterial;
        }
    }
}