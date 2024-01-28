using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace the_haha
{
    public class SmartDialogue :Singleton<SmartDialogue>
    {
        public TextMeshProUGUI textComponent;
        public List<string> lines;
        public float textSpeed = 0.01f;
        private bool _finishedDialogue = true;

        private new void Awake()
        {   
            base.Awake();
            gameObject.SetActive(false);
            textComponent.text = string.Empty;
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0) && _finishedDialogue)
            {
                NextLine();
            } else if (Input.GetMouseButtonDown(0) && !_finishedDialogue)
            {
                StopAllCoroutines();
                PopLine();
                NextLine();
            }
        }
        
        public void AddLines(List<string> newLines)
        {
            lines.AddRange(newLines);
        }
        
        private void PopLine()
        {
            lines.RemoveAt(0);
        }
        
        public void StartDialogue()
        {
            _finishedDialogue = false;
            gameObject.SetActive(true);
            StartCoroutine(TypeLine());
        }
        
        private IEnumerator TypeLine()
        {
            foreach (var c in lines[0])
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
            PopLine();
            _finishedDialogue = true;
        }

        private void NextLine()
        {
            if (lines.Count > 0)
            {
                textComponent.text = string.Empty;
                StopAllCoroutines();
                StartCoroutine(TypeLine());
            }
            else 
            {
                textComponent.text = string.Empty;
                gameObject.SetActive(false);
                StopAllCoroutines();
            }
        }
    }
}
