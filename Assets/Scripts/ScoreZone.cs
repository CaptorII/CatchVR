using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public int health = 100;
    int healthMax = 100;
    int healthMin = 0;

    private void OnTriggerEnter(Collider other)
    {

    }

    public void UpdateHealth(int value)
    {
        health += value;
        if (health > healthMax)
        {
            health = healthMax;
        }
        else if (health <= healthMin)
        {
            health = healthMin;
            PauseControl.instance.GameOver();
        }
    }
}
