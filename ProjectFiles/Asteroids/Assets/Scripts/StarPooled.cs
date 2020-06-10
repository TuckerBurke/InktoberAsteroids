using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Represents a single star object within a pool                       *
//*                                                                         *
//*     METHODS                                                             *
//*     void OnEnable()                                                     *
//*     void Update()                                                       *
//*                                                                         *
//***************************************************************************

public class StarPooled : MonoBehaviour
{
    // Local variables
    private Vector3 starPosition;       // Position of the star on screen
    public  float screenHeight = 14f;   // Adjustable screen height in unity units
    public  float screenWidth = 25f;    // Adjustable screen width in unity unit
    private float lifeTime;             // Acts as a timer to track time elapsed
    private float randomX;              // Random X position
    private float randomY;              // Random Y position
    private float scaler;               // Linear scaler for size

    [SerializeField]
    private float maxLifeTime = 0.24f;  // The duration the star stays on screen

    // Called each time this object is re enabled *************************************
    private void OnEnable()
    {
        // Reset timer
        lifeTime = 0f;

        // Generate a random location on screen
        randomX = Random.Range(-screenWidth, screenWidth);
        randomY = Random.Range(-screenHeight, screenHeight);

        // Randomly adjust star's scale
        scaler = Random.Range(0.5f, 1.2f);

        // Apply these transformations
        starPosition = new Vector3(randomX, randomY, 0f);
        transform.position = starPosition;
        transform.localScale = new Vector3(scaler, scaler, 1f);

    }//END OnEnable

    // Update is called once per frame ************************************************
    void Update()
    {
        // Count up lifetime
        lifeTime += Time.deltaTime;

        // Check lifetime
        if (lifeTime >= maxLifeTime)
        {
            // Send back to the pool
            StarPool.Instance.ReturnToPool(this);
        }

    }//END Update()
}
