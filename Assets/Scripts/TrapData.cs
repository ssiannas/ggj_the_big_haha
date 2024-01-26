using UnityEngine;

namespace the_haha
{
    [CreateAssetMenu(fileName = "New Trap", menuName = "GameObjects/Traps", order = 1)]
    public class TrapData : ScriptableObject
    {
        public string name;
        [SerializeField, Range(0, 100)]
        public int damage;
        [SerializeField, Range(0, InterestMeterController.MaxInterestLevel)]
        public int amusement;
    }
}
