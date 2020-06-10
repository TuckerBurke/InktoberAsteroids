using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Calculates and handles collisions for Ship, Missles, and            *
//*     asteroids.                                                          *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void Update()                                                       *
//*     void GatherMissleAssets()                                           *
//*     void GatherLargeAssets()                                            *
//*     void GatherSmallAssets()                                            *
//*     void ShipCollision()                                                *
//*     void BulletCollision()                                              *
//*                                                                         *
//***************************************************************************

public class Collisions : MonoBehaviour
{
    private GameObject ship;                 // Reference to the player game object
    public  GameObject bullet;               // Reference to store a temp bullet
    private GameObject[] missles;            // Array of references to all missles on screen
    private GameObject[] smallAsteroids;     // Array of references to all the smaller asteroid
    public  GameObject[] largeAsteroids;     // Array of references to all large asteroids
    private SpriteRenderer shipBox;          // Reference to get player bounds and center
    private SpriteRenderer[] missleBoxes;    // Array of references to all missle render boxes
    private SpriteRenderer[] smallBoxes;     // Array of references to all the small asteroid sprite boxes
    public  SpriteRenderer[] largeBoxes;     // Array of references to large asteroid sprite boxes
    public  ScreenShake screenShake;         // Reference to the Camera with screen shake
    
    private float shipRadius;                // Stores the ship radius, as it doesn't change
    private float bulletRadius;              // Static bullet radius
    public  bool gameActive = true;          // Game state
    private bool[] missleFlags;              // Array of collision flags for missles
    private bool[] smallFlags;               // Array of collision flags for small asteroids
    private bool[] largeFlags;               // Array of collision flags for large asteroids
    
    // Properties
    public bool GameActive { set { gameActive = value; } }  // Allows adjustment of game state

    // Use this for initialization **********************************************************
    void Start()
    {
        // Get a reference to the ship object and its bounds
        ship = GameObject.Find("ship");
        shipBox = ship.GetComponent<SpriteRenderer>();

        // Calculate ship radius
        shipRadius = shipBox.bounds.max.y - shipBox.bounds.center.y;

        // Get a reference to the missle object and its bounds
        SpriteRenderer bulletBox = bullet.GetComponent<SpriteRenderer>();

        // Calculate bullets radius
        bulletRadius = bulletBox.bounds.max.y - bulletBox.bounds.center.y;

    }// END Start()
	
	// Update is called once per frame ******************************************************
	void Update()
    {
        // If the game is active
        if (gameActive)
        {
            // Detect bullet collision
            GatherMissleAssets();
            GatherLargeAssets();
            GatherSmallAssets();
            BulletCollision();

            // Detect ship collision
            GatherLargeAssets();
            GatherSmallAssets();
            ShipCollision();        
        }

	}// END Update()

    // Gather references to all missles and sprite renderers *********************************
    //(to be replaced with custom data structure at a later date)
    void GatherMissleAssets()
    {
        // Collect missles
        missles = GameObject.FindGameObjectsWithTag("pew");

        // Adjust size of array containing missle sprite renderers and flags
        missleBoxes = new SpriteRenderer[missles.Length];
        missleFlags = new bool[missles.Length];

        // For all the missles
        for (int i = 0; i < missles.Length; i++)
        {
            // Store a reference to the missles sprite renderer
            missleBoxes[i] = missles[i].GetComponent<SpriteRenderer>();
        }

    }// END GatherMissleAssets()

    // Gather references to all large asteroids and sprite renderers ***************************
    //(to be replaced with custom data structure at a later date)
    void GatherLargeAssets()
    {
        // Collect large asteroids
        largeAsteroids = GameObject.FindGameObjectsWithTag("large");

        // Adjust size of array containing large sprite renderers and flags
        largeBoxes = new SpriteRenderer[largeAsteroids.Length];
        largeFlags = new bool[largeAsteroids.Length];

        // For all the large asteroids
        for (int i = 0; i < largeAsteroids.Length; i++)
        {
            // Store a reference to the large asteroid sprite renderer
            largeBoxes[i] = largeAsteroids[i].GetComponent<SpriteRenderer>();
        }

    }// END GatherLargeAssets()

    // Gather references to all large asteroids and sprite renderers **************************
    //(to be replaced with custom data structure at a later date)
    void GatherSmallAssets()
    {
        // Collect small asteroids
        smallAsteroids = GameObject.FindGameObjectsWithTag("small");

        // Adjust size of array containing small sprite renderers and flags
        smallBoxes = new SpriteRenderer[smallAsteroids.Length];
        smallFlags = new bool[smallAsteroids.Length];

        // For all the large asteroids
        for (int i = 0; i < smallAsteroids.Length; i++)
        {
            // Store a reference to the large asteroid sprite renderer
            smallBoxes[i] = smallAsteroids[i].GetComponent<SpriteRenderer>();
        }

    }// END GatherSmallAssets()

    // Compare ship to asteroids and flag collisions *******************************************
    void ShipCollision()
    {
        // For all large asteroids
        for (int i = 0; i < largeBoxes.Length; i++)
        {
            // Calculate the asteroids radius
            float currentRadius = largeBoxes[i].bounds.max.y - largeBoxes[i].bounds.center.y;

            // Calculate distance between ship and asteroid
            Vector3 distance = shipBox.bounds.center - largeBoxes[i].bounds.center;

            // If sum of radii is greater than distance
            if (shipRadius + currentRadius > distance.magnitude)
            {
                // Collision occurred
                ship.GetComponent<Shields>().OnCollision();
            }
        }

        // For all small asteroids
        for (int i = 0; i < smallBoxes.Length; i++)
        {
            // Calculate the asteroids radius
            float currentRadius = smallBoxes[i].bounds.max.y - smallBoxes[i].bounds.center.y;

            // Calculate distance between ship and asteroid
            Vector3 distance = shipBox.bounds.center - smallBoxes[i].bounds.center;

            // If sum of radii is greater than distance
            if (shipRadius + currentRadius > distance.magnitude)
            {
                // Collision occurred
                ship.GetComponent<Shields>().OnCollision();
            }
        }

    }// END ShipCollision()

    // Compare bullet location to small and large asteroids ********************************************
    void BulletCollision()
    {
        // For all bullets
        for (int h = 0; h < missleBoxes.Length; h++)
        {
            // For all large asteroids
            for (int i = 0; i < largeBoxes.Length; i++)
            {
                // Calculate the asteroids radius
                float asteroidRadius = largeBoxes[i].bounds.max.y - largeBoxes[i].bounds.center.y;

                // Calculate distance between ship and asteroid
                Vector3 distance = missleBoxes[h].bounds.center - largeBoxes[i].bounds.center;

                // If sum of radii is greater than distance
                if (bulletRadius + asteroidRadius > distance.magnitude)
                {
                    // Trigger score pop up
                    largeAsteroids[i].GetComponent<ScorePopUp>().PopUp("" + 1000);

                    // Trigger explosion animation
                    largeAsteroids[i].GetComponent<Explosion>().Explode(1.75f);

                    // Trigger screen shake
                    StartCoroutine(screenShake.Shake(0.1f, 0.2f));

                    // Collision occurred
                    missles[h].GetComponent<BulletFlight>().OnCollision();
                    largeAsteroids[i].GetComponent<AsteroidFlight>().OnCollision();                 
                }

            }

            // For all small asteroids
            for (int i = 0; i < smallBoxes.Length; i++)
            {
                // Calculate the asteroids radius
                float asteroidRadius = smallBoxes[i].bounds.max.y - smallBoxes[i].bounds.center.y;

                // Calculate distance between ship and asteroid
                Vector3 distance = missleBoxes[h].bounds.center - smallBoxes[i].bounds.center;

                // If sum of radii is greater than distance
                if (bulletRadius + asteroidRadius > distance.magnitude)
                {
                    // Trigger score pop up
                    smallAsteroids[i].GetComponent<ScorePopUp>().PopUp("" + 500);

                    // Trigger explosion animation
                    smallAsteroids[i].GetComponent<Explosion>().Explode(1.2f);

                    // Trigger screen shake
                    StartCoroutine(screenShake.Shake(0.07f, 0.15f));

                    // Collision occurred
                    missles[h].GetComponent<BulletFlight>().OnCollision();
                    smallAsteroids[i].GetComponent<CrumbleFlight>().OnCollision();
                }

            }
        }

    }// END BulletCollision ()
}
