using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace the_haha
{
    public class SmartDialogue :Singleton<SmartDialogue>
    {
        public TextMeshProUGUI textComponent;
        public string[] lines;
        public float textSpeed;
        private int index;
        // Start is called before the first frame update
        void Start()
        {
            textComponent.text = string.Empty;
            gameObject.SetActive(false);
            //StartDialogue();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == lines[index])
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
        }

        void NextLine()
        {
            if (index < lines.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else 
            {
                gameObject.SetActive(false);
            }

        }
    }
}
