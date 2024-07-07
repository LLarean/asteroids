using Asteroids.Scripts.Global;
using UnityEngine;

namespace Asteroids.Scripts.Project
{
    public class AudioPlayer : MonoBehaviour
    {
        public static AudioPlayer Instance = null;
        
        [Header("Audio Sources")]
        [SerializeField]
        private AudioSource _music;
        [SerializeField]
        private AudioSource _sound;
        [Header("Music")]
        [SerializeField]
        private AudioClip _menuMusic;
        [SerializeField]
        private AudioClip _gameMusic;
        [Header("Sounds")]
        [SerializeField]
        private AudioClip _click;

        [ContextMenu("PlayMenuMusic")]
        public void PlayMenuMusic()
        {
            _music.clip = _menuMusic;
            _music.Play();
        }

        public void PlayGameMusic()
        {
            _music.clip = _gameMusic;
            _music.Play();
        }

        public void PlayClick() => _sound.PlayOneShot(_click);

        public void SetMusicVolume(float value) => _music.volume = value;

        public void SetSoundVolume(float value) => _sound.volume = value;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if(Instance == this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
            
            _sound.loop = true;

            if (PlayerPrefs.HasKey(GlobalStrings.Music) == true)
            {
                SetMusicVolume(PlayerPrefs.GetFloat(GlobalStrings.Music));
            }
            else
            {
                _music.volume = GlobalSettings.DefaultMusicVolume;
            }
            
            if (PlayerPrefs.HasKey(GlobalStrings.Sound) == true)
            {
                SetSoundVolume(PlayerPrefs.GetFloat(GlobalStrings.Sound));
            }
            else
            {
                _sound.volume = GlobalSettings.DefaultSoundVolume;
            }
        }
    }
}