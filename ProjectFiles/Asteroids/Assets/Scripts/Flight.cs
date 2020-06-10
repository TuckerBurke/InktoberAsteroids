using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Handles player ship movement, physics and controls                  *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void Update()                                                       *
//*     void Turn()                                                         *
//*     void Advance()                                                      *
//*     void SetTransform()                                                 *
//*                                                                         *
//***************************************************************************

public class Flight : MonoBehaviour {

    // Local variables
    private AudioSource thrusterAudio;  // Storing since the audio source will be used frequently
    public Vector3 vehiclePos;          // Vehicles current x y coordinate
    public Vector3 direction;           // Unit vector indicating the direction vehicle is facing
    public Vector3 velocity;            // Stores current speed and direction
    public Vector3 acceleration;        // Thrust and direction, added to velocity
    public float maxSpeed = 0.2f;       // Clamps magnetude of velocity
    public float turnSpeed = 1.5f;      // Degrees per frame
    public float thrust = 0.18f;        // Rate of acceleration
    public float brake = 0.92f;         // Rate of deceleration
    public float dragModifier = 0.07f;  // Added to brake to compute drag (reduced version of brake)
    public bool slide = true;           // Toggles if velocity is effected by direction
    public bool drag = true;            // Toggles if object decelerates naturally
    
    // Use this for initialization *****************************************************
    void Start()
    {
        // Initialize vectors
        vehiclePos = new Vector3(0, 0);
        direction = new Vector3(0, 1);
        velocity = new Vector3(0, 0);
        acceleration = new Vector3(0, 0);

        // Store reference to the attached audio source
        thrusterAudio = GetComponent<AudioSource>();

    }// END Start ()

    // Update is called once per frame *************************************************
    void Update()
    {
        // Aquire updated position (for compatability with other scripts)
        vehiclePos = transform.position;

        // Complete physics cycle
        Turn();
        Advance();
        SetTransform();

    }// END Update()

    // Handles vehicle stearing ***************************************************
    void Turn()
    {
        // If A pressed
        if (Input.GetKey(KeyCode.A))
        {
            // Rotate 1 degree clockwise
            direction = Quaternion.Euler(0, 0, turnSpeed) * direction;
        }

        // If D pressed
        else if (Input.GetKey(KeyCode.D))
        {
            // Rotate 1 degree counter clockwise
            direction = Quaternion.Euler(0, 0, -turnSpeed) * direction;
        }

    }// END Turn()

    // Handles vehicle acceleration and deceleration *******************************
    void Advance()
    {
        // If W pressed
        if (Input.GetKey(KeyCode.W))
        {
            // Combine rate of acceleration with direction
            acceleration = thrust * direction;

            // Increment velocity
            velocity += acceleration * Time.deltaTime;

            // If thruster audio is not already playing
            if (!thrusterAudio.isPlaying)
            {
                // Then play thruster audio
                thrusterAudio.Play();
            }
        }

        // If W released
        if (Input.GetKeyUp(KeyCode.W))
        {
            // Then stop playing thruster audio
            thrusterAudio.Stop();
        }

        // If S pressed
        else if (Input.GetKey(KeyCode.S)) // E Brake
        {
            // Decrement velocity
            velocity *= brake;

            // If speed falls below threshold
            if (velocity.magnitude < 0.02f)
            {
                // Set to zero
                velocity = Vector3.zero;
            }
        }

        // If drag applied
        if (drag)
        {
            // If thrust is not being applied
            if (!Input.GetKey(KeyCode.W))
            {
                // Apply brake
                velocity *= brake + dragModifier;
            }

        }

        // If not sliding
        if (!slide)
        {
            // Velocity is in the same direction as vehicle is facing
            velocity = velocity.magnitude * direction;
        }

        // Set a maximum speed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // Store vehicles new position
        vehiclePos += velocity;

    }// END Advance()

    // Updates vehicle transform
    void SetTransform()
    {
        // Update prefab position based on stored variable
        transform.position = vehiclePos;

        // Determine angle of rotation based on direction vector
        float angle = Mathf.Atan2(direction.y, direction.x);

        // Convert to degrees
        angle *= Mathf.Rad2Deg;

        // Update prefab rotation based on stored variable
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }// END SetTransform()
}
