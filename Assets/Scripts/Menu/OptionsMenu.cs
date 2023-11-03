using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    public void ReturnToMain()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
