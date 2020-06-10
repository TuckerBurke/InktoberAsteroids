using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Keeps track of score and displays it in the UI                      *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void AddPoints(int)                                                 *
//*                                                                         *
//***************************************************************************

public class ScoreHUD : MonoBehaviour
{
    public GameObject selectedPrefab;   // Drag and drop game reference
    GameObject scoreBoard;              // Text object displaying player score
    static public int score;            // The player's current score
    TextMesh scoreDisplay;              // The score's text component

    // Use this for initialization ********************************************
    void Start ()
    {
        // Initialize game score
        score = 0;

        // Instantiate HUD
        scoreBoard = Instantiate(selectedPrefab);

        // Display initial score
        scoreDisplay = scoreBoard.GetComponentInChildren<TextMesh>();
        scoreDisplay.text = score.ToString();

    }// END Start ()

    // Called to add points to game score **********************************
    public void AddPoints(int points)
    {
        // Add passed points to game score
        score += points;
        scoreDisplay.text = score.ToString();

    }// END AddPoints (int points)
}
