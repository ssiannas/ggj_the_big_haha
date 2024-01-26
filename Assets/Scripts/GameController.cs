using UnityEngine;

namespace the_haha
{
    [RequireComponent(typeof(InterestMeterController))]
    public class GameController : Singleton<GameController>
    {
        public delegate void GameOverDelegate();
        public static event GameOverDelegate OnGameOver;
        
        [SerializeField]
        private GameObject deathScreen;
        
        private InterestMeterController _interestMeterController;
        // Start is called before the first frame update
        private new void Awake()
        {
            base.Awake();
            _interestMeterController = GetComponent<InterestMeterController>();
        }

        // Update is called once per frame
        private void Update()
        {
            _interestMeterController.DecrementInterestLevelTick(); 
        }

        public void GameOver()
        {
            deathScreen.SetActive(true);
            Destroy(_interestMeterController.gameObject);
            OnGameOver?.Invoke();
        }
    }
}
