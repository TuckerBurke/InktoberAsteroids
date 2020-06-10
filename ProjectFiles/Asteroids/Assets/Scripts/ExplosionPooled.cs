using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Represents a single explosion sprite queued within a pool           *
//*     Date: 06.08.20                                                      *
//*                                                                         *
//*     METHODS                                                             *
//*     void OnEnable()                                                     *
//*     void Update()                                                       *
//*                                                                         *
//***************************************************************************

public class ExplosionPooled : MonoBehaviour
{
    [SerializeField] 
    private float maxLifeTime = 0.24f;     // Maximum duration the explosion can exist
    private float lifeTime;                // Current lifetime towards said duration
    
    // Called whenever the object in enabled *******************************************
    private void OnEnable()
    {
        // Reset the lifetime counter
        lifeTime = 0f;

    }// END OnEnable()

    // Update is called once per frame *************************************************
    void Update()
    {
        // Count time passed in the current lifetime 
        lifeTime += Time.deltaTime;

        // If time exceeds max duration
        if (lifeTime > maxLifeTime)
        {
            // Pool this object
            ExplosionPool.Instance.ReturnToPool(this);
        }

    }// END Update()
}
    
