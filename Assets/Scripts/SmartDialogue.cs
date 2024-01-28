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
        public float textSpeed = 0.1f;
        void Start()
        {
            textComponent.text = string.Empty;
            gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
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
            gameObject.SetActive(true);
            StartCoroutine(TypeLine());
        }
        
        private IEnumerator TypeLine()
        {
            foreach (char c in lines[0].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
            PopLine();
        }

        private void NextLine()
        {
            if (lines.Count > 0)
            {
                textComponent.text = string.Empty;
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
