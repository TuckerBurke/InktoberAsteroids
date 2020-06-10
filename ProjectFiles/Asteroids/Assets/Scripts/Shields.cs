using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Stores players shield level, handles reductions and                 *
//*     invulnerability. This is where ship explosion animation is          *
//*     called.                                                             *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void Update()                                                       *
//*     void OnCollision()                                                  *
//*                                                                         *
//***************************************************************************

public class Shields : MonoBehaviour
{
    // Local Variables
    public int shieldCount;             // Number of shields remaining
    public int timer;                   // Counts down cool down for invulnerability
    public int buffLength = 90;         // Length of invulnerability cool down
    public bool invulnerable = false;   // Invulnerability state
    public GameObject gameManager;      // Reference to the game manager
    public Color shipAlpha;             // The color containing alpha
    
    [SerializeField] 
    private GameObject lightningPrefab; // Lightning aura child prefab

    [SerializeField]
    private SpriteRenderer shipSprite;   // For alpha control

    // Accessors
    public int ShieldCount { get; }                         // Shield count, read only
    public int BuffLength { set { buffLength = value; } }   // Length of invulnerability, write only
    public bool Invulnerable { get; }                       // Returns the ships invulnerability state


    // Use this for initialization ********************************************
    void Start()
    {
        // Initialize starting shield count
        shieldCount = 3;

        // Get a reference to the game manager
        gameManager = GameObject.Find("GameManager");

        // Store initial color
        shipAlpha = shipSprite.color;

	}// END Start()
	
	// Update is called once per frame ****************************************
	void Update()
    {
        // Countdown
        timer--;

        // If timer has reached zero
        if (timer < 1)
        {
            // Stop counting down
            timer = 0;

            // Deactivate shield animation
            lightningPrefab.SetActive(false);

            // Change ship transparency
            shipAlpha.a = 1f;
            shipSprite.color = shipAlpha;

            // Ship is no longer invulnerable
            invulnerable = false;

            // If shield count is zero
            if (shieldCount == 0)
            {
                // End the game
                gameManager.GetComponent<GameOver>().EndGame();
            }
        } 

	}// END Update()

    // Called when ship is in a collision **************************************
    public void OnCollision()
    {
        // If the ship isn't invulnerable
        if (!invulnerable)
        {
            // Trigger explosion animation
            GetComponent<Explosion>().Explode(1.6f);

            // Trigger shield animation
            lightningPrefab.SetActive(true);

            // Change ship transparency
            shipAlpha.a = 0.25f;
            shipSprite.color = shipAlpha;

            // Lose a shield point
            shieldCount--;

            // Reset cool down timer
            timer = buffLength;

            // Ship is temporarily invulnerable to additional damage
            invulnerable = true;

            // Update HUD via GameManager
            gameManager.GetComponent<ShieldHUD>().TakeDamage();
        } 

    }// END OnCollision()

}
