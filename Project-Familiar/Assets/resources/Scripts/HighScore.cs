using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public TMP_Text scoreDisplay;

    void Start()
    {
        scoreDisplay.text = PlayerController.highScore.ToString();
    }
}