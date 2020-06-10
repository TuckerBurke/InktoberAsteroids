using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Causes screen shake after scene transition                          *
//*                                                                         *
//*     METHODS                                                             *
//*     void Awake()                                                        *
//*                                                                         *
//***************************************************************************

public class ShakeAwake : MonoBehaviour
{
    public ScreenShake screenShake;     // Reference to the Camera with screen shake

    // Called the first time object is loaded
    void Awake()
    {
        // Shake screen
        StartCoroutine(screenShake.Shake(0.5f, 0.8f));
    }
}
