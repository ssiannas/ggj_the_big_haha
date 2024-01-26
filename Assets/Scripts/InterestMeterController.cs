using TMPro;
using UnityEngine;

namespace the_haha
{
    public class InterestMeterController : MonoBehaviour
    {
        public const int MaxInterestLevel = 100;
        [SerializeField, Range(0, MaxInterestLevel)]
        private int interestLevel = MaxInterestLevel / 2;
        private TextMeshProUGUI _interestLevelIndicator;
        
        
        [SerializeField, Range(0, 10)]
        private float interestDecreaseTime = 5;

        private float _timeToNextInterestDecrease;

        private void Awake()
        {
            _interestLevelIndicator = GameObject.FindWithTag("InterestMeter").GetComponent<TextMeshProUGUI>();
            _timeToNextInterestDecrease = interestDecreaseTime;
            UpdateInterestLevelIndicator();
        }
        public void DecrementInterestLevelByAmount(int amount=1)
        {
            interestLevel -= amount;
            UpdateInterestLevelIndicator();
        }
        
        public void IncrementInterestLevelByAmount(int amount=1)
        {
            interestLevel += amount;
            UpdateInterestLevelIndicator();
        }
        
        public void DecrementInterestLevelTick()
        {
            _timeToNextInterestDecrease -= Time.deltaTime;
            if (_timeToNextInterestDecrease > 0)
            {
                return;
            }
            _timeToNextInterestDecrease = interestDecreaseTime;
            DecrementInterestLevelByAmount();
        }

        private void UpdateInterestLevelIndicator()
        {
            if (interestLevel <= 0)
            {
                GameController.Instance.GameOver();
            }

            _interestLevelIndicator.text = interestLevel.ToString();
        }

    }
}
