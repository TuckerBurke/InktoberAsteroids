using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Generates random attributes for an asteroid being spawned           *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void RandomAttributes()                                             *
//*     void SetTransform()                                                 *
//*                                                                         *
//***************************************************************************

public class SpawnAttributesRandom : MonoBehaviour
{
    // Local variables
    private SpriteRenderer  thisRenderer;        // The asteroid's sprite box
    public  Vector3         asteroidPosition;    // Position of the asteroid
    private Vector3         size;                // Random scale of the asteroid
    private float           radius;              // The asteroid's radius
    public  float           angle;               // The direction as an Euler angle
    public  int             screenHeight = 14;   // Adjustable screen height in unity units
    public  int             screenWidth = 25;    // Adjustable screen width in unity units
    public  int             quadrant;            // The side of the screen the asteroid will spawn
    public  int             heading;             // The direction the asteroid will travel
    System.Random rand;                          // Will be used to initialize a number of attributes

    // Use this for initialization *************************************************
    void Start()
    {
        // Store a reference to this objects sprite renderer
        thisRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        // Compute this objects radii (assuming its not dynamic)
        radius = thisRenderer.bounds.center.x - thisRenderer.bounds.min.x;

        // Initialize random number generator
        rand = new System.Random();

        // Select spawn location
        RandomAttributes();

        // Apply initial tranformations
        SetTransform();

    }// END Start()

    // Determines random spawn location *********************************************
    void RandomAttributes()
    {
        // Local variables
        Vector3 spawnLocation = new Vector3();

        // Determine spawn quadrant
        quadrant = rand.Next(4);

        // Generate random angular range
        int range = rand.Next(170);

        // Generate random scale
        float scale = UnityEngine.Random.Range(0.6f, 1.0f);
        size = new Vector3(scale, scale);

        // If top quad
        if (quadrant == 0)
        {
            // Place in top margin
            spawnLocation.y = (screenHeight + radius) * 0.99f;

            // Determine random X position
            spawnLocation.x = (rand.Next(51) - screenWidth);

            // Random heading between 185 - 355 degrees
            heading = range + 185;
        }

        // If bottom quad
        else if (quadrant == 1)
        {
            // Place in bottom margin
            spawnLocation.y = (screenHeight + radius) * -0.99f;

            // Determine random X position
            spawnLocation.x = (rand.Next(51) - screenWidth);

            // Random heading between 5 - 175 degrees
            heading = range + 5;
        }

        // If left quad
        else if (quadrant == 2)
        {
            // Place in left margin
            spawnLocation.x = (screenWidth + radius) * -0.99f;

            // Determine random Y position
            spawnLocation.y = (rand.Next(29) - screenHeight);

            // Random heading between -85 - +85 degrees
            heading = range - 85;
        }

        // If right quad
        else
        {
            // Place in right margin
            spawnLocation.x = (screenWidth + radius) * 0.99f;

            // Determine random Y position
            spawnLocation.y = (rand.Next(29) - screenHeight);

            // Random heading between 95 - 265 degrees
            heading = range + 95;
        }

        // Store initial location
        asteroidPosition = spawnLocation;

        // Store initial heading
        angle = heading;

    }// END RandomAttributes()

    // Updates asteroid tranformations *******************************************
    void SetTransform()
    {
        // Update prefab position 
        transform.position = asteroidPosition;

        // Update prefab scale
        transform.localScale = size;

        // Update prefab rotation 
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }// END SetTransform()

}
