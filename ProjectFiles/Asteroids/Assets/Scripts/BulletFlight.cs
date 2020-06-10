using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Handles the movement of bullets / missles                           *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void Update()                                                       *
//*     void OnCollision()                                                  *
//*                                                                         *
//***************************************************************************

public class BulletFlight : MonoBehaviour
{
    // Local Variables
    public Vector3 direction;       // Stores initial direction
    public Vector3 bulletPosition;  // Vector on which to compute before applying to transform
    public Vector3 velocity;        // Speed and direction of bullet
    public float speed = 19.2f;     // Projectile speed (1.5 x max ship speed)

	// Use this for initialization *****************************************************
	void Start ()
    {
        // Store initial bullet position
        bulletPosition = transform.position;

        // Determine initial angle
        float heading = transform.eulerAngles.z;

        // Convert for trig
        heading = heading * Mathf.Deg2Rad;

        // Create normalized vector based on heading
        direction.x = Mathf.Cos(heading);
        direction.y = Mathf.Sin(heading);

        // Scale based on speed
        velocity = speed * direction * Time.deltaTime;

	}// END Start ()
	
	// Update is called once per frame ************************************************
	void Update ()
    {
        // Update position variable
        bulletPosition += velocity;

        // Apply to transformation
        transform.position = bulletPosition;
		
	}// END Update ()

    // Called when a missle is in a collision *****************************************
    public void OnCollision()
    {
        // Destroy the missle
        Destroy(gameObject);

    }// END OnCollision ()
}
