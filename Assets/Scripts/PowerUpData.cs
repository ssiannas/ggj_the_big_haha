using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    [CreateAssetMenu(fileName = "PowerUpData", menuName = "GameObjects/PowerUps")]
    public class PowerUpData : ScriptableObject
    {
        public int cost;
        public string description;
        public string powerUpName;
        //public string dialogue;
    }
}
