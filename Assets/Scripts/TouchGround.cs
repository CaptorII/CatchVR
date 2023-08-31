using TMPro;
using UnityEngine;

public class TouchGround : MonoBehaviour
{
    public int score = 0;
    [SerializeField]
    TextMeshProUGUI scoreLabel;

    public void UpdateScore(int scoreIncrease)
    {
        score += scoreIncrease;
    }

    public void UpdateScoreDisplay()
    {
        scoreLabel.SetText("Score: " + score.ToString());
    }
}
