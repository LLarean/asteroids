using Asteroids.Scripts.Global;
using Asteroids.Scripts.Project;
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
        [SerializeField]
        private Slider _musicVolume;
        [SerializeField]
        private Slider _soundVolume;

        public void ShowScreen() => gameObject.SetActive(true);

        private void Start()
        {
            _back.onClick.AddListener(ShowMainMenu);
            _musicVolume.onValueChanged.AddListener(SetMusicVolume);
            _soundVolume.onValueChanged.AddListener(SetSoundVolume);
        }

        private void ShowMainMenu()
        {
            AudioPlayer.Instance.PlayClick();
            _mainScreen.ShowScreen();
            gameObject.SetActive(false);
        }

        private void SetMusicVolume(float value)
        {
            PlayerPrefs.SetFloat(GlobalStrings.Music, value);
            AudioPlayer.Instance.SetMusicVolume(value);
        }

        private void SetSoundVolume(float value)
        {
            PlayerPrefs.SetFloat(GlobalStrings.Sound, value);
            AudioPlayer.Instance.SetSoundVolume(value);
        }

        private void OnEnable()
        {
            if (PlayerPrefs.HasKey(GlobalStrings.Music) == true)
            {
                SetMusicVolume(PlayerPrefs.GetFloat(GlobalStrings.Music));
            }
            else
            {
                _musicVolume.value = GlobalSettings.DefaultMusicVolume;
            }
            
            if (PlayerPrefs.HasKey(GlobalStrings.Sound) == true)
            {
                SetSoundVolume(PlayerPrefs.GetFloat(GlobalStrings.Sound));
            }
            else
            {
                _soundVolume.value = GlobalSettings.DefaultSoundVolume;
            }
        }
    }
}
