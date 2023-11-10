//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    void Start()
    {
        PauseControl.instance.pause += Pause;
    }

    public void Pause(bool paused)
    {
        gameObject.SetActive(paused);
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
}
