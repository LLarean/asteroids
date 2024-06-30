using Asteroids.Scripts.Global;
using Asteroids.Scripts.Project;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Asteroids.Scripts.Menu
{
    public class MainScreen : MonoBehaviour
    {
        [SerializeField]
        private SettingsScreen _settingsScreen;
        [SerializeField]
        private Button _settings;
        [SerializeField]
        private Button _play;

        public void ShowScreen() => gameObject.SetActive(true);

        private void Start()
        {
            _settings.onClick.AddListener(ShowSettings);
            _play.onClick.AddListener(LoadGame);
        }

        private void LoadGame()
        {
            SceneManager.LoadScene(GlobalStrings.Game);
        }

        private void ShowSettings()
        {
            AudioPlayer.Instance.PlayClick();
            _settingsScreen.ShowScreen();
            gameObject.SetActive(false);
        }
    }
}
