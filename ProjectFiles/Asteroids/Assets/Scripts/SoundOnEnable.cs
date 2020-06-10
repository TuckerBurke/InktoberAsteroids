using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Plays attached audio source whenever this object gets enabled       *
//*                                                                         *
//*     METHODS                                                             *
//*     void OnEnable()                                                     *
//*                                                                         *
//***************************************************************************

public class SoundOnEnable : MonoBehaviour
{
    // Plays audio when object is enabled
    void OnEnable()
    {
        // Get this objects audio source and play it
        GetComponent<AudioSource>().Play();

    }// END OnEnable()
}
