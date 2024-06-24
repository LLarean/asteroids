using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatScreen : MonoBehaviour
{
    [SerializeField]
    private Button _restart;

    private void Start()
    {
        _restart.onClick.AddListener(RestartMatch);
    }

    private void RestartMatch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}