using TMPro;
using UnityEngine;

namespace the_haha
{
    public class InterestMeterController : Singleton<InterestMeterController>
    {
        public const int MaxInterestLevel = 100;
        [SerializeField, Range(0, MaxInterestLevel)]
        private int interestLevel = MaxInterestLevel / 2;
        private TextMeshProUGUI _interestLevelIndicator;
        
        
        [SerializeField, Range(0, 10)]
        private float interestDecreaseTime = 5;

        private float _timeToNextInterestDecrease;

        private new void Awake()
        {
            base.Awake();
            var interestMeter = GameObject.FindWithTag("InterestMeter");
            interestMeter.SetActive(false);
            // TODO: Should eplace with a proper class
            _interestLevelIndicator = interestMeter.GetComponentInChildren<TextMeshProUGUI>();
            _timeToNextInterestDecrease = interestDecreaseTime;
            UpdateInterestLevelIndicator();
        }
        
        public void ShowInterestMeter()
        {
            var interestMeter = GameObject.FindWithTag("InterestMeter");
            interestMeter.SetActive(true);
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
            if (_interestLevelIndicator)
                _interestLevelIndicator.text = interestLevel.ToString();
        }

    }
}
