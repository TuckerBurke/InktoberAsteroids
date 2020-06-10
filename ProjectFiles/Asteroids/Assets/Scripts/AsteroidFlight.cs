using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Initializes asteroids with random attributes and controls           *
//*     their movement                                                      *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void Update()                                                       *
//*     void OnCollision()                                                  *
//*                                                                         *
//***************************************************************************

public class AsteroidFlight : MonoBehaviour
{
    // Local variables
    public GameObject gameManager;      // Reference to the Game Manager
    public Vector3 direction;           // Stores initial direction
    public Vector3 asteroidPosition;    // Vector on which to compute before applying to transform
    public Vector3 velocity;            // Speed and direction of bullet
    public float speed;                 // Asteroid speed semi randomly generated
    public float revolve;               // Asteroid revolution rate semi randomly generated
    public float angle;                 // Cumulative revolution

    // Properties
    public int Direction { get; }       // To pass initial direction to asteroid crumbles

    // Use this for initialization *********************************************************
    void Start ()
    {
        // Initialize random speed
        speed = Random.Range(3.0f, 15.0f);

        // Initialize random revolution
        revolve = Random.Range(-2.0f, 2.0f);

        // Store initial asteroid position
        asteroidPosition = transform.position;

        // Determine initial angle
        float heading = transform.eulerAngles.z;

        // Convert for trig
        heading = heading * Mathf.Deg2Rad;

        // Create normalized vector based on heading
        direction.x = Mathf.Cos(heading);
        direction.y = Mathf.Sin(heading);

        // Scale based on speed
        velocity = speed * direction;

        // Grab reference to the game manager
        gameManager = GameObject.Find("GameManager");

    }// END Start ()
	
	// Update is called once per frame *****************************************
	void Update ()
    {
        // Aquire updated position (for compatability with other scripts)
        asteroidPosition = transform.position;

        // Update position variable
        asteroidPosition += velocity * Time.deltaTime;

        // Update asteroid revolution
        angle += revolve;

        // Apply to transformation
        transform.position = asteroidPosition;

        // Update prefab rotation based on cumulative revolution
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }// END Update ()

    // Called when a large asteroid is in a collision ******************************
    public void OnCollision()
    {
        // Crumble the asteroid
        gameObject.GetComponent<CrumbleAsteroid>().Crumble();

        // Destroy the destroy the asteroid
        Destroy(gameObject);

        // Increment score
        gameManager.GetComponent<ScoreHUD>().AddPoints(1000);

    }// END OnCollision ()
}
