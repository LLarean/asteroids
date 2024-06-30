using Asteroids.Scripts.Project;
using UnityEngine;

namespace Asteroids.Scripts.Menu
{
    public class MenuEntryPoint : MonoBehaviour
    {
        [SerializeField]
        private MainScreen _mainScreen;
        [SerializeField]
        private SettingsScreen _settingsScreen;

        private void Start()
        {
            AudioPlayer.Instance.PlayMenuMusic();
            _mainScreen.gameObject.SetActive(true);
            _settingsScreen.gameObject.SetActive(false);
        }
    }
}