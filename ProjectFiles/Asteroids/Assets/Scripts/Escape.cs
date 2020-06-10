using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using UnityEngine;
using UnityEngine.SceneManagement;

//***************************************************************************
//*                                                                         *
//*     Escapes on key press to main menu after playing a sound             *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void Update()                                                       *
//*                                                                         *
//***************************************************************************

public class Escape : MonoBehaviour
{
    [SerializeField] private AudioSource escapeSound;
    private float soundDuration;
    private float counter = 0f;
    private bool escaping = false;
   
    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the Audio Source attached to this object
        escapeSound = GetComponent<AudioSource>();

        // Calculate the length of the audio clip
        soundDuration = escapeSound.clip.length;

    }// END Start()

    // Update is called once per frame
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
            // Add to counter
            counter += Time.deltaTime;

            // if the counter exceeds duration
            if (counter >= soundDuration)
            {
                // Return to splash screen
                SceneManager.LoadScene(sceneName: "start");
            }
        }

    }// END Update()
}
