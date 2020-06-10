using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//***************************************************************************
//*                                                                         *
//*     Splash screen visualization and menu operations                     *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void Update()                                                       *
//*                                                                         *
//***************************************************************************

public class StartGame : MonoBehaviour
{
    private float soundDuration;
    private float timeElapsed;
    private bool beginning = false;
    [SerializeField] private GameObject anyKeyObject;

    // Start is called before the first frame update ***********************************
    void Start()
    {
        // See if there is still a scoreHUD
        GameObject scoreHUD = GameObject.Find("scoreText(Clone)");
        GameObject anyKeyObject = GameObject.Find("PressAnyKey");

        // If there is still a scoreHUD, destroy it
        Destroy(scoreHUD);

        // Detect the length of the passed in sound
        soundDuration = GetComponent<AudioSource>().clip.length;

    }//END Start()

    // Update is called once per frame *************************************************
    void Update() 
    {
        // If any key is pressed
        if(Input.anyKey)
        {
            // If it was the esc key
            if(Input.GetKey(KeyCode.Escape))
            {
                // Quit the game
                Application.Quit();

                // Play the quit sound
                GetComponent<AudioSource>().Play();
            }
            // Otherwise
            else
            {
                // Play the menu sound effect
                anyKeyObject.GetComponent<AudioSource>().Play();

                // Begin counter
                beginning = true;

                // Disable menu
                anyKeyObject.transform.position = new Vector3(0f, -15f, 1f);
            }
        }

        // If beginning counter has started
        if (beginning)
        {
            // Count time
            timeElapsed += Time.deltaTime;
        }

        // If time passed is greater than sound duration
        if (timeElapsed >= soundDuration)
        {
            // Reset timer
            timeElapsed = 0f;

            // Begin the game
            SceneManager.LoadScene(sceneName: "game");
        }

    }// END Update()
}
