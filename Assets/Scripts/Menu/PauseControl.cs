using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

/// <summary>
/// PauseControl handles pausing and unpausing the game through the menu button on the controller and the pause menu.
/// </summary>
public class PauseControl : MonoBehaviour
{
    public event Delegates.VoidBoolDel pause;
    public static PauseControl instance;
    bool paused = false;
    bool gameOver = false;
    public UnityEvent death;
    InputDevice leftController;
    [SerializeField] GameObject pauseMenu;
    bool menuButton = false;
    bool menuButtonPrev = false;

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

    private void Start()
    {
        leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }

    void Update()
    {
        if (gameOver) { return; }
        if (leftController == null || leftController.isValid == false) // if controller is not yet detected, try again every frame
        {
            List<InputDevice> devices = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller, devices);
            if(devices.Count > 0)
            {
                leftController = devices[0];
            }
        }
        // if menu button is pressed, pause game
        menuButtonPrev = menuButton;
        leftController.TryGetFeatureValue(CommonUsages.menuButton, out menuButton);
        bool menuDown = !menuButtonPrev && menuButton;
        bool menuUp = menuButtonPrev && !menuButton;
        if (menuDown)
        {
            paused = !paused; // inverts paused, sets false if true or vice versa
            Time.timeScale = paused ?  0f : 1f; // freeze time if paused, resume if unpaused            
            pause?.Invoke(paused); 
            pauseMenu.SetActive(paused); // show or hide pause menu
        }
    }

    public void UnPause() // called by button on pause menu
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
