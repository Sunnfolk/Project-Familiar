using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public TMP_Text scoreDisplay;
    public TMP_Text highScoreDisplay;

    void Start()
    {
        scoreDisplay.text = "" + PlayerController.PlayerScore;
        highScoreDisplay.text = "" + PlayerController.HighScore;
    }
}