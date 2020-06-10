using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Used by game manager to spawn random asteroids                      *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void Update()                                                       *
//*     void PickAsteroid()                                                 *
//*                                                                         *
//***************************************************************************

public class SpawnAsteroids : MonoBehaviour
{
    // Local variables
    public int frameCounter;                                // Tracks frames
    public float spawnTime = 10f;                           // Seconds between spawns
    public GameObject[] largeAsteroids = new GameObject[3]; // Array of asteroids to choose from
    public GameObject selectedPrefab;                       // The asteroid selected
    System.Random rand;                                     // For random selection
    public bool gameActive = true;                          // Game state

    // Accessors
    public bool GameActive { set { gameActive = value; } }  // Adjusts the game state

    // Use this for initialization *********************************************************
    void Start()
    {
        // Initialize random number generator
        rand = new System.Random();

        // Initialize frame count to spawn immediately
        frameCounter = (int)spawnTime * 60;

	}// END Start()
	
	// Update is called once per frame *****************************************************
	void Update()
    {
        // If the game is active
        if (gameActive)
        {
            // If frame count exceeds spawn time
            if (frameCounter >= spawnTime * 60)
            {
                // Choose from large asteroid prefabs
                selectedPrefab = PickAsteroid();

                // Spawn a large asteroid
                Instantiate(selectedPrefab);

                // Add to custom data structure

                // Reset counter
                frameCounter = 0;
            }

            // Increment frame count
            frameCounter++;
        }

	}// END Update()

    // Picks from the three asteroid prefabs *************************************************
    GameObject PickAsteroid()
    {
        // Local variables
        GameObject luckyAsteroid;   // Selected asteroid to return

        // Randomly pick a number
        int index = rand.Next(3);

        // Pluck from array
        luckyAsteroid = largeAsteroids[index];

        // Return asteroid to instantiate
        return luckyAsteroid;

    }// END PickAsteroid()
}
