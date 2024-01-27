using UnityEngine;

namespace the_haha
{
    [RequireComponent(typeof(InterestMeterController))]
    public class GameController : Singleton<GameController>
    {
        public delegate void GameOverDelegate();
        public event GameOverDelegate OnGameOver;
        private bool _isDecrementing = true;
        
        [SerializeField, InspectorName("Haha bucks")]
        public int currency = 50;
        private float realcurrency = 50.0f;
        [SerializeField]
        private int currencyPerTick = 1;
        [SerializeField]
        private bool _isInDungeon = false;

        private bool _isPaused = false;
        
        // Start is called before the first frame update
        private new void Awake()
        {
            base.Awake();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_isPaused) return;
            if (_isDecrementing) InterestMeterController.Instance.DecrementInterestLevelTick();
            realcurrency += currencyPerTick * Time.deltaTime;
            currency = (int)realcurrency;
        }

        public void EnterDungeon()
        {
            // Load dungeon scene
            // start timers
            _isInDungeon = true;
            _isDecrementing = true;
           InterestMeterController.Instance.ShowInterestMeter(); 
        }

        public void Pause()
        {
            _isPaused = true;
        }
        
        public void Unpause()
        {
            _isPaused = false;
        }
        
        public void GameOver()
        {
            _isDecrementing = false;
            OnGameOver?.Invoke();
        }

        public int GetCoins()
        {
            return currency;
        }

        public void SetCoins(int coins)
        {
            currency = coins;
            realcurrency = coins;
        }


        public void AddCurrencyPerTcik()
        {
            currencyPerTick ++;
        }
    }
}
