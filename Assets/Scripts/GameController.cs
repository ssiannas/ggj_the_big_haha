using UnityEngine;

namespace the_haha
{
    [RequireComponent(typeof(InterestMeterController))]
    public class GameController : Singleton<GameController>
    {
        public delegate void GameOverDelegate();
        public event GameOverDelegate OnGameOver;
        private bool _isDecrementing = false;
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
            if (_isDecrementing) _interestMeterController.DecrementInterestLevelTick();
        }

        public void GameOver()
        {
            _isDecrementing = false;
            OnGameOver?.Invoke();
        }
    }
}
