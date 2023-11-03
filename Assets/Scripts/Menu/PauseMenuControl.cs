using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    void Start()
    {
        PauseControl.instance.pause += Pause;
        gameObject.SetActive(false);
    }

    public void Pause(bool paused)
    {
        gameObject.SetActive(paused);
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
}
