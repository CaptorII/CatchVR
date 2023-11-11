using TMPro;
using UnityEngine;

/// <summary>
/// ScoreZone is a script on the 'score zone' below the player which controls health and taking damage when objects reach it.
/// This class has a link to the UI to display health.
/// </summary>
public class ScoreZone : MonoBehaviour
{
    public int health = 100;
    int healthMax = 100;
    int healthMin = 0;
    [SerializeField] TextMeshProUGUI healthLabel;
    AudioClip gameOverSound;

    private void Start()
    {
        health = 100;
    }

    public void UpdateHealth(int value)
    {
        health += value;
        if (health > healthMax)
        {
            health = healthMax; // ensure health does not exceed maximum
        }
        else if (health <= healthMin) // if health reaches minimum, trigger game over
        {
            health = healthMin;
            AudioSource source = GetComponent<AudioSource>();
            gameOverSound = (AudioClip)Resources.Load("Audio/Crash");
            source.clip = gameOverSound;
            source.Play();
            PauseControl.instance.GameOver();
        }
    }

    public void UpdateHealthDisplay()
    {
        healthLabel.SetText("Health: " + health);
    }
}
