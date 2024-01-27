using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace the_haha
{
    public class ButtonController : MonoBehaviour
    {
        [SerializeField] private UnityEvent onButtonPress = new();

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void PressButton()
        {
            onButtonPress.Invoke();
        }
    }
}