using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public int score = 100;
    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void UpdateScore()
    {
        score--;
    }
}
