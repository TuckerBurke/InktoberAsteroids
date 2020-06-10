using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//***************************************************************************
//*                                                                         *
//*     Handles input and execution of menu options on the game over        *
//*     screen                                                              *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void Update()                                                       *
//*                                                                         *
//***************************************************************************

public class GameOverMenu : MonoBehaviour
{
    // Local variables
    [SerializeField] private AudioSource escapeSound;   // Game ojects Audio Source component
    private float soundDuration;                        // Length of the sound clip
    private bool escaping = false;                      // Menu state (so sound clip finishes prior to scene switch)
    private float timer = 0f;                         // Counts change in time to act as a timer compared to sound duration

    // Start is called before the first frame update  ***************************************************************************
    void Start()
    {
        // Store game object's audio source
        escapeSound = GetComponent<AudioSource>();

        // Calculate the length of the sound clip
        soundDuration = escapeSound.clip.length;

    }// END Start()

    // Update is called once per frame  *****************************************************************************************
    void Update()
    {
        // If any key is pressed
        if (Input.GetKey(KeyCode.Escape))
        {
            // Play audio feedback
            escapeSound.Play();

            // Begin countdown
            escaping = true;
        }

        // If escaping game over screen
        if (escaping)
        {
            // Add to timer
            timer += Time.deltaTime;

            // if the timer exceeds duration
            if (timer >= soundDuration)
            {
                // Return to splash screen
                SceneManager.LoadScene(sceneName: "start");
            }
        }

    }// END Update()
}