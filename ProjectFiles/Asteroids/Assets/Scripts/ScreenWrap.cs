using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Handles the wrapping of objects around the game screen              *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void Update()                                                       *
//*     void Wrap()                                                         *
//*                                                                         *
//***************************************************************************

public class ScreenWrap : MonoBehaviour 
{
    // Local variables
    public Vector3 position;            // Current object's position
    public SpriteRenderer thisRenderer; // Current object's sprite box
    public float radius;                // Radius of the object
    public float screenHeight = 14f;    // Adjustable screen height in unity units
    public float screenWidth = 25f;     // Adjustable screen width in unity units

    // Use this for initialization ************************************************
    void Start()
    {
        // Store a reference to this objects sprite renderer
        thisRenderer = gameObject.GetComponent<SpriteRenderer>();

        // Compute this objects radii (assuming its not dynamic)
        radius = thisRenderer.bounds.center.x - thisRenderer.bounds.min.x;

    }// END Start ()
	
	// Update is called once per frame ********************************************
	void Update()
    {

        // Get current position to analyze
        position = transform.position;

        // Execute screen wrapping
        Wrap();

	}// END Update()

    // Handles screen wrapping *****************************************************
    // Note: **** 0.99f used to make sure relocated within screen bounds ***********
    void Wrap()
    {
        // If off right
        if (position.x - radius > screenWidth * 1.03f)
        {
            // Move to left
            position.x = (screenWidth + radius) * -1f;
        }

        // If off left
        if (position.x + radius < -screenWidth * 1.03f)
        {
            // Move to right
            position.x = (screenWidth + radius);
        }

        // If off top
        if (position.y - radius > screenHeight * 1.03f)
        {
            // Move to bottom
            position.y = (screenHeight + radius) * -1f;
        }

        // If off bottom
        if (position.y + radius < -screenHeight * 1.03f)
        {
            // Move to top
            position.y = (screenHeight + radius);
        }
        
        // Apply transformation
        gameObject.transform.position = position;

    }// END Wrap()
}
