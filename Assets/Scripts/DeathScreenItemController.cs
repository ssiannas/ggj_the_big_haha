using UnityEngine;

namespace the_haha
{
    public class DeathScreenItemController : MonoBehaviour
    {
        private void Start()
        {
            var gc = GameController.Instance;
            if (gameObject.activeSelf) gameObject.SetActive(false);
            gc.OnGameOver += OnGameOver;
        }

        private void OnGameOver()
        {
            gameObject.SetActive(true);
        }
    }
}
