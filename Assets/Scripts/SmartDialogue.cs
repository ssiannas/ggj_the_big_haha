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
        private int index;
        // Start is called before the first frame update
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
                if (lines.Count > 0)
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
        
        public void AddLineEnd(string line)
        {
            lines.Add(line);
        }
        
        public void AddLineStart(string line)
        {
            lines.Insert(0, line);
        }
        
        public void PopLine()
        {
            lines.RemoveAt(0);
            index--;
        }
        
        public void StartDialogue()
        {
            gameObject.SetActive(true);
            index = 0;
            StartCoroutine(TypeLine());
        }
        IEnumerator TypeLine()
        {
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
            PopLine();
        }

        void NextLine()
        {
            if (index < lines.Count - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else 
            {
                textComponent.text = string.Empty;
                gameObject.SetActive(false);
            }

        }
    }
}
