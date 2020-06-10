using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Handles the firing of projectiles by the player                     *
//*     Date: 06.08.20                                                      *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                     *
//*     void Update()                                                       *
//*                                                                         *
//***************************************************************************

public class Fire : MonoBehaviour
{
    // Local variables
    public GameObject projectile = null;    // For drag and drop object integration
    public float rateOfFire = 4f;           // Number of projectiles per second
    public int frameCounter;                // Frame counter

	// Use this for initialization ****************************************************
	void Start ()
    {
        // Initialize frame count
        frameCounter = 0;

	}// END Start ()
	
	// Update is called once per frame ************************************************
	void Update ()
    {
        // Manage rate of fire
        if (frameCounter > 60 / rateOfFire)
        {
            // If Space Bar pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Create a projectile
                Instantiate(projectile, transform.position, transform.rotation);

                // Add to custom data structure

                // Reset counter
                frameCounter = 0;
            }

        }

        // Increment timer
        frameCounter++;

    }// END Update ()
}
