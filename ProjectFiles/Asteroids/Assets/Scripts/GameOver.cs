using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//***************************************************************************
//*                                                                         *
//*     This component executes the game over game state                    *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void EndGame()                                                      *
//*     void DestroyAssets()                                                *
//*     void GameOverScreen()                                               *
//*                                                                         *
//***************************************************************************

public class GameOver : MonoBehaviour {

    // Local variables
    public GameObject gameOverText;     // Game over notification text object
    public Vector3 endScorePosition;    // Location to move the score at game over

	// Use this for initialization *************************************************
	void Start()
    {
        // Location of score when the game ends
        endScorePosition = new Vector3(0, -8);

	}// END Start()

    // Function which ends the game ************************************************
    public void EndGame()
    {
        // Turn off processes
        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<SpawnAsteroids>().GameActive = false;
        GameObject collisionDetection = GameObject.Find("CollisionManager");
        collisionDetection.GetComponent<Collisions>().GameActive = false;

        // Destroy all game assets
        DestroyAssets();

        // Display game over scene
        GameOverScreen();

    }// END EndGame()

    // Removes all game assets from the scene **************************************
    void DestroyAssets()
    {
        // Destroy ship
        GameObject ship = GameObject.Find("ship");
        Destroy(ship);

        // Destroy bullets
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("pew");

        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }

        // Destroy small asteroids
        GameObject[] small = GameObject.FindGameObjectsWithTag("small");

        for (int i = 0; i < small.Length; i++)
        {
            Destroy(small[i]);
        }

        // Destroy large asteroids
        GameObject[] large = GameObject.FindGameObjectsWithTag("large");

        for (int i = 0; i < large.Length; i++)
        {
            Destroy(large[i]);
        }

    }// END DestroyAssets()

    // Displays the game over screen ****************************************
    void GameOverScreen()
    {
        // Switch scenes
        SceneManager.LoadScene(sceneName: "gameOver");

    }// END GameOverScreen()
}
