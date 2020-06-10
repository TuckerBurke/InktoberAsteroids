using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Method to create a visual explosion, utilizing generic object       *
//*     pooling template                                                    *
//*                                                                         *
//*     METHODS                                                             *
//*     void Expload(scaler)                                                *
//*                                                                         *
//***************************************************************************

public class Explosion : MonoBehaviour
{
    public void Explode(float scaler)
    {
        // Get an explosion instance from the pool
        var boom = ExplosionPool.Instance.Get();

        // Inherit this objects position
        boom.transform.position = transform.position;

        // Adjust size by passed in scaler
        boom.transform.localScale *= scaler;

        // Enable the explosion object
        boom.gameObject.SetActive(true);
    }
}
