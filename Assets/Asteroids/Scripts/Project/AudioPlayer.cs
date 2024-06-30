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

        public void PlayMenuMusic()
        {
            _sound.clip = _menuMusic;
            _sound.Play();
        }

        public void PlayGameMusic()
        {
            _sound.clip = _gameMusic;
            _sound.Play();
        }

        public void PlayClick()
        {
            _sound.PlayOneShot(_click);
        }

        private void Start ()
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
        }
    }
}