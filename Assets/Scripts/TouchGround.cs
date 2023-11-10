using TMPro;
using UnityEngine;

public class TouchGround : MonoBehaviour
{
    public int score = 0;
    [SerializeField] int levelOneThreshold = 20;
    [SerializeField] int levelTwoThreshold = 50;
    [SerializeField] float speedUpAmount = 0.8f;
    [SerializeField] TextMeshProUGUI scoreLabel;

    public void UpdateScore(int scoreIncrease)
    {
        score += scoreIncrease;
        if (score == levelOneThreshold)
        {
            SpawnPoint.level += 1;
        }
        if (score == levelTwoThreshold)
        {
            SpawnPoint.level += 1;
        }
        if (score % levelTwoThreshold == 0 && score != levelTwoThreshold) // at 100 points, then 150, 200 etc.
        {
            SpawnPoint.spawnDelay *= speedUpAmount; // reduce delay between things spawning to increase difficulty
        }
    }

    public void UpdateScoreDisplay()
    {
        scoreLabel.SetText("Score: " + score.ToString());
    }
}
