using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
