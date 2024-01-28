using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using TMPro;
using UnityEditor.Rendering;
using UnityEngine.SceneManagement;


namespace the_haha
{
    [RequireComponent(typeof(InterestMeterController))]
    public class GameController : Singleton<GameController>
    {
        public delegate void GameOverDelegate();
        public event GameOverDelegate OnGameOver;
        private bool _isDecrementing = false;
        
        [SerializeField, InspectorName("Haha bucks")]
        public int currency = 50;
        private float _realcurrency = 50.0f;
        [SerializeField]
        private int currencyPerTick = 1;
        [SerializeField]
        private bool _isInDungeon = false;
        private bool _isPaused = false;

        private TextMeshProUGUI _coinCounter;
        private GameObject _player = null;

        [SerializeField] GameObject _playerPrefab;
        [SerializeField] private Transform _spawnPoint;

        private new void Awake()
        {
            if (_instance != null)
            {
                return;
            }
            base.Awake();
            
            SpawnPlayer();
        }

        private void Start()
        {
           ShowStartDialogue();
           var audioManager = AudioManager.Instance;
           audioManager.Play("EvilLaugh");
        }

        private void ShowStartDialogue()
        {   
            SmartDialogue.Instance.AddLines(Constants.StartDialogue.ToList());
            SmartDialogue.Instance.StartDialogue();
        }
        
        private void SpawnPlayer()
        {
            var sp = GameObject.FindWithTag("SpawnPoint");
            if (sp == null) return;
            _spawnPoint = sp.transform;
            var playerRotation = _spawnPoint.rotation;
            if (_player == null)
            {
                _player = Instantiate(_playerPrefab, _spawnPoint.position, playerRotation);
                DontDestroyOnLoad(_player.gameObject);
            }
            else
            {
                _player.transform.position = _spawnPoint.position;
                _player.transform.rotation = _spawnPoint.rotation;
            }

            var mainCamera = GameObject.FindWithTag("MainCamera");
            var cameraFollow = mainCamera.GetComponent<CameraFollow>();
            cameraFollow.SetTarget(_player);
        }
        // Update is called once per frame
        private void Update()
        {
            if (_isPaused) return;
            if (_isDecrementing) InterestMeterController.Instance.DecrementInterestLevelTick();
            if (_isInDungeon) IncrementCurrency();
            showCurrency();
        }
        
        private void IncrementCurrency()
        {
            _realcurrency += currencyPerTick * Time.deltaTime;
            currency = (int)_realcurrency;
        }
        private void OnDungeonEntered()
        {
            SpawnPlayer();
            // start timers
            InterestMeterController.Instance.SetUpInterestMeter();
            _isInDungeon = true;
            _isDecrementing = true;
            InterestMeterController.Instance.ShowInterestMeter(); 
        }
        private IEnumerator EnterDungeonCoroutine()
        {
            //hardcoded
            var asyncLoadLevel = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            while (!asyncLoadLevel.isDone){
                yield return null;
            } 
            OnDungeonEntered();
        }
        
        public void EnterDungeon()
        {
            StartCoroutine(EnterDungeonCoroutine());
        }

        private void OnSpawnEntered()
        {
            SpawnPlayer();
            _isInDungeon = false;
            _isDecrementing = false;
        }
        private IEnumerator EnterSpawnCoroutine()
        {
           var loadSpawnAsync = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
           while (!loadSpawnAsync.isDone) yield return null;
           OnSpawnEntered();
        }
        
        private void EnterSpawn()
        {
            StartCoroutine(EnterSpawnCoroutine());
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
            EnterSpawn(); 
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
            if (coinCounter != null)
            {
                _coinCounter = coinCounter.GetComponentInChildren<TextMeshProUGUI>();
                _coinCounter.text = currency.ToString();
            }
        }
    }
}
