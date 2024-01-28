using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    [CreateAssetMenu(fileName = "ObjectiveData", menuName = "GameObjects/Objective")]
    public class ObjectiveData : ScriptableObject
    {
        public int amusement;
        public string objectiveName;
        public string[] dialogue;
    }
}
