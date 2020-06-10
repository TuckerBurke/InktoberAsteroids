using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Class that controls small asteroid movement and some                *
//*     random attribute generation.                                        *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void Update()                                                       *
//*     void OnCollision()                                                  *
//*                                                                         *
//***************************************************************************

public class CrumbleFlight : MonoBehaviour {

    // Local variables
    public Vector3 direction;       // Stores initial direction
    public Vector3 crumblePosition; // Vector on which to compute before applying to transform
    public Vector3 velocity;        // Speed and direction of bullet
    public float speed;             // Projectile speed (1.5 x max ship speed)
    public float revolve;           // Asteroid revolution rate semi randomly generated
    public float angle;             // Cumulative revolution
    public Vector3 size;            // Randomly generated asteroid scale
    public GameObject gameManager;  // Reference to the game manager

    // Use this for initialization ***********************************************
    void Start ()
    {
        // Store initial bullet position
        crumblePosition = transform.position;

        // Determine initial angle
        float heading = transform.eulerAngles.z;

        // Deviation from initial course
        heading += Random.Range(-30f, 30f);

        // Unit vector for multiplication of quaternion
        direction = new Vector3(1, 0);

        // Apply heading to the vector
        direction = Quaternion.Euler(0, 0, heading) * direction;

        // Initialize random revolution
        revolve = Random.Range(-2.0f, 2.0f);

        // Generate random scale
        float scale = UnityEngine.Random.Range(0.6f, 1.0f);
        size = new Vector3(scale, scale);
        transform.localScale = size;

        // Apply variance to speeds
        speed = Random.Range(3f, 12f);

        // Scale based on speed
        velocity = speed * direction * Time.deltaTime;

        // Grab reference to the game manager
        gameManager = GameObject.Find("GameManager");

    }// END Start ()
	
	// Update is called once per frame *******************************************
	void Update ()
    {
        // Aquire updated position (for compatability with other scripts)
        crumblePosition = transform.position;

        // Update position variable
        crumblePosition += velocity;

        // Update asteroid revolution
        angle += revolve;

        // Apply to transformation
        transform.position = crumblePosition;

        // Update prefab rotation based on cumulative revolution
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }// END Update ()

    // Called when a crumble is in a collision ***********************************
    public void OnCollision()
    {
        // Destroy the crumble
        Destroy(gameObject);

        // Increment score
        gameManager.GetComponent<ScoreHUD>().AddPoints(500);

    }// END OnCollision ()
}
