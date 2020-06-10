using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Attach this script to an object to prevent its destruction          *
//*     during screen transition.                                           *
//*                                                                         *
//*     METHODS                                                             *
//*     void Awake()                                                        *
//*                                                                         *
//***************************************************************************

public class DontDestroy : MonoBehaviour
{
    // Awake called once the first time object is created
    void Awake()
    {
        // Don't destroy this object
        DontDestroyOnLoad(gameObject.transform);

    }// END Awake()
}
