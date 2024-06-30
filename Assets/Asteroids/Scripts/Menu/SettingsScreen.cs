using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Scripts.Menu
{
    public class SettingsScreen : MonoBehaviour
    {
        [SerializeField]
        private MainScreen _mainScreen;
        [SerializeField]
        private Button _back;

        public void ShowScreen() => gameObject.SetActive(true);

        private void Start()
        {
            _back.onClick.AddListener(ShowMainMenu);
        }

        private void ShowMainMenu()
        {
            _mainScreen.ShowScreen();
            gameObject.SetActive(false);
        }
    }
}
