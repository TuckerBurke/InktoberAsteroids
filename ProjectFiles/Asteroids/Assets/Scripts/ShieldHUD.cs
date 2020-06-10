using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Handles the display of player shields (health)                      *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void TakeDamage()                                                   *
//*                                                                         *
//***************************************************************************

public class ShieldHUD : MonoBehaviour
{
    // Local Variables
    public GameObject selectedPrefab;   // Drag and drop object reference
    public Vector3 shieldPosition1;     // Location of the first shield in HUD
    public Vector3 shieldPosition2;     // Location of the second shield in HUD
    public Vector3 shieldPosition3;     // Location of the third shield in HUD
    public ScreenShake screenShake;     // Reference to the Camera with screen shake
    GameObject[] shieldHUD;             // Collection of shield prefabs

    // Use this for initialization *******************************************
    void Start()
    {
        // Positions for shield icons
        shieldPosition1 = new Vector3(-12.5f, 10, 0);
        shieldPosition2 = new Vector3(-10, 10, 0);
        shieldPosition3 = new Vector3(-7.5f, 10, 0);

        // Instantiate shield icons
        Instantiate(selectedPrefab, shieldPosition1, Quaternion.identity);
        Instantiate(selectedPrefab, shieldPosition2, Quaternion.identity);
        Instantiate(selectedPrefab, shieldPosition3, Quaternion.identity);

        // Collect references to shield prefabs
        shieldHUD = GameObject.FindGameObjectsWithTag("shield");

    }// END Start()

    // Updates HUD graphics *************************************************
    public void TakeDamage()
    {
        if (shieldHUD[2])
        {
            // Trigger explosion animation
            shieldHUD[2].GetComponent<Explosion>().Explode(1.6f);

            // Remove corresponding shield indicator from HUD
            Destroy(shieldHUD[2]);
            shieldHUD[2] = null;

            // Shake screen
            StartCoroutine(screenShake.Shake(0.15f, 0.4f));
        }
        else if (shieldHUD[1])
        {
            // Trigger explosion animation
            shieldHUD[1].GetComponent<Explosion>().Explode(1.7f);

            // Remove corresponding shield indicator from HUD
            Destroy(shieldHUD[1]);
            shieldHUD[1] = null;

            // Shake screen
            StartCoroutine(screenShake.Shake(0.25f, 0.6f));
        }
        else if (shieldHUD[0])
        {
            // Trigger explosion animation
            shieldHUD[0].GetComponent<Explosion>().Explode(1.8f);

            // Remove corresponding shield indicator from HUD
            Destroy(shieldHUD[0]);
            shieldHUD[0] = null;

            // Shake screen
            StartCoroutine(screenShake.Shake(0.5f, 0.8f));
        }

    }// END TakeDamage()
}
