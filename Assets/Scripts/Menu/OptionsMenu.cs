using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] Material brightnessMat;

    public void UpdateVolume(float newVolume)
    {
        masterMixer.SetFloat("SFX", newVolume);
    }

    public void UpdateBrightness(float newBrightness)
    {
        float constrained = 1 - (newBrightness);
        if (constrained > 0.8f)
        {
            constrained = 0.8f;
        }
        Color brightness = new Color(0f, 0f, 0f, constrained);
        brightnessMat.SetColor("_Color", brightness);
    }

    public void Return(GameObject prevMenu)
    {
        prevMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
