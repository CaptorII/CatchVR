using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Options Menu provides controls for both in-game and pre-game options menus. 
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] Material brightnessMat;

    public void UpdateVolume(float newVolume)
    {
        masterMixer.SetFloat("SFX", newVolume); // set volume of sound effects (all sound in this build)
    }

    public void UpdateBrightness(float newBrightness)
    {
        float constrained = 1 - (newBrightness);
        if (constrained > 0.8f) // ensure brightness does not go below 20%
        {
            constrained = 0.8f;
        }
        Color brightness = new Color(0f, 0f, 0f, constrained); // set opacity to inverse of brightness
        brightnessMat.SetColor("_Color", brightness);
    }

    public void Return(GameObject prevMenu)
    {
        prevMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
