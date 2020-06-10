using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

//***************************************************************************
//*                                                                         *
//*     Method to summon a background star, utilizing generic object        *
//*     pooling template                                                    *
//*                                                                         *
//*     METHODS                                                             *
//*     void Summon()                                                       *
//*                                                                         *
//***************************************************************************

public class Star : MonoBehaviour
{
    public void Summon()
    {
        // Generate a star for or from the pool
        var star = StarPool.Instance.Get();

        // Enable the pooled object
        star.gameObject.SetActive(true);

    }// END Summon()
}
