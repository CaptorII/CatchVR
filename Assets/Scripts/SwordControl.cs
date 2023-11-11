using UnityEngine;

/// <summary>
/// SwordControl is a script for loading sounds for clashing swords, healing and taking damage from not deflecting weapons.
/// </summary>
public class SwordControl : MonoBehaviour
{
    public static Object[] swordSounds;
    public static AudioClip healingSound;
    public static AudioClip damageSound;

    private void Start()
    {
        swordSounds = Resources.LoadAll("Audio/SwordStrikes", typeof(AudioClip));
        healingSound = (AudioClip)Resources.Load("Audio/Heal");
        damageSound = (AudioClip)Resources.Load("Audio/Damage");
    }
}
