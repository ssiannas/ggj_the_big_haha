using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace the_haha
{
    public enum PowerUpType
    {
        SPEED,
        DECAY_DOWN,
        MONEY_UP,
        DMG_DOWN
    }
    [CreateAssetMenu(fileName = "PowerUpData", menuName = "GameObjects/PowerUps")]
    public class PowerUpData : ScriptableObject
    {
        public int cost;
        public string description;
        public string powerUpName;
        public PowerUpType PowerUpType;
        //public string dialogue;
    }
}
