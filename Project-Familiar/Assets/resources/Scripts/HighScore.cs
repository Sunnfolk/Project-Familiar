using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public TMP_Text scoreDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = "High Score: "+PlayerController.highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
