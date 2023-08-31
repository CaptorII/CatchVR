using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseControl : MonoBehaviour
{
    public event Delegates.VoidBoolDel pause;
    public static PauseControl instance;
    bool paused = false;
    bool gameOver = false;
    public UnityEvent death;

    void Awake()
    {
        Time.timeScale = 1f;
        if (instance != null && instance != this) // if there is an instance of pausemenu already in place
        {
            Destroy(instance); // destroy it
        }
        instance = this;
        DontDestroyOnLoad(gameObject); // prevents object being destroyed when next scene is entered
    }

    void Update()
    {
        if (gameOver) { return; }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            paused = !paused; // inverts paused, sets false if true or vice versa
            if (paused)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
            pause?.Invoke(paused);
        }
    }

    public void UnPause()
    {
        paused = false;
        Time.timeScale = 1f;
        pause?.Invoke(paused);
    }

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0f;
        death.Invoke();
    }
}
