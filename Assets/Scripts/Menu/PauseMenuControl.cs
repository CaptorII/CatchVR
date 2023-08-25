using UnityEngine;

public class PauseMenuControl : MonoBehaviour
{
    void Start()
    {
        PauseControl.instance.pause += Pause;
        gameObject.SetActive(false);
    }

    void Pause(bool paused)
    {
        gameObject.SetActive(paused);
    }
}
