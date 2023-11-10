using TMPro;
using UnityEngine;

public class TouchGround : MonoBehaviour
{
    public int score = 0;
    [SerializeField] int levelOneThreshold = 20;
    [SerializeField] int levelTwoThreshold = 50;
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
    }

    public void UpdateScoreDisplay()
    {
        scoreLabel.SetText("Score: " + score.ToString());
    }
}
