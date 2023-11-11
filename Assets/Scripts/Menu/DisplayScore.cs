using TMPro;
using UnityEngine;

/// <summary>
/// DisplayScore is a script on the 'Game over' menu, only instantiated once the player loses.
/// Script is used only to get the final score from the ground and display it in the game over menu.
/// </summary>
public class DisplayScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreLabel;
    [SerializeField] TouchGround ground;
    void Start()
    {
        scoreLabel.SetText(ground.score.ToString());
    }
}
