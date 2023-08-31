using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreLabel;
    [SerializeField]
    TouchGround ground;
    void Start()
    {
        scoreLabel.SetText(ground.score.ToString());
    }
}
