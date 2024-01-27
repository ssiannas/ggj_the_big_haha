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
        private int currency = 0;
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
            currency += currencyPerTick * (int)Time.deltaTime;
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
    }
}
