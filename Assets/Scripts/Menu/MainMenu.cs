using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
}
