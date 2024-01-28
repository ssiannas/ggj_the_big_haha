using System.Collections.Generic;
using UnityEngine;

using TMPro;

using UnityEngine.SceneManagement;


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
        private float _realcurrency = 50.0f;
        [SerializeField]
        private int currencyPerTick = 1;
        [SerializeField]
        private bool _isInDungeon = false;
        private bool _isPaused = false;

        private TextMeshProUGUI _coinCounter;


        [SerializeField] GameObject _playerPrefab;
        [SerializeField] private Transform _spawnPoint;

        private new void Awake()
        {
            base.Awake();
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            var sp = GameObject.FindWithTag("SpawnPoint");
            if (sp == null) return;
            
            _spawnPoint = sp.transform;
            var playerRotation = _spawnPoint.rotation;
            var player = Instantiate(_playerPrefab, _spawnPoint.position, playerRotation);
            var mainCamera = GameObject.FindWithTag("MainCamera");
            var cameraFollow = mainCamera.GetComponent<CameraFollow>();
            cameraFollow.SetTarget(player);
        }
        // Update is called once per frame
        private void Update()
        {
            if (_isPaused) return;
            if (_isDecrementing) InterestMeterController.Instance.DecrementInterestLevelTick();

            _realcurrency += currencyPerTick * Time.deltaTime;
            currency = (int)_realcurrency;
            showCurrency();
        }
        
        
        public void EnterDungeon()
        {
            //hardcoded
            SceneManager.LoadScene(1);
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
            _realcurrency = coins;
        }


        public void AddCurrencyPerTcik()
        {
            currencyPerTick ++;
        }

        private void showCurrency()
        {

            var coinCounter = GameObject.FindWithTag("Coins");
            _coinCounter = coinCounter.GetComponentInChildren<TextMeshProUGUI>();
            _coinCounter.text = currency.ToString();
        }
    }
}
