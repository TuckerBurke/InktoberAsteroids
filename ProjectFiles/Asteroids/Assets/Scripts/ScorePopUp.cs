using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

//***************************************************************************
//*                                                                         *
//*     Add a pop up to the screen via a generic pool template.             *
//*                                                                         *
//*     METHODS                                                             *
//*     void PopUp(string)                                                  *
//*                                                                         *
//***************************************************************************

public class ScorePopUp : MonoBehaviour
{
    // Creates a score pop up of the passed in string
    public void PopUp(string _points)
    {
        // Create object via pooling and store it
        var score = ScorePopUpPool.Instance.Get();

        // Give it the passed parameter
        score.Points = _points;

        // Inherit this objects position
        score.transform.position = transform.position;

        // Enable the pop up score object
        score.gameObject.SetActive(true);

    }// END PopUp()
}
