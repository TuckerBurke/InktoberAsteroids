using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

//***************************************************************************
//*                                                                         *
//*     Represents a single pop up text object within a pool                *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void OnEnable()                                                     *
//*     void Update()                                                       *
//*                                                                         *
//***************************************************************************

public class ScorePopUpPooled : MonoBehaviour
{
    // Local variables
    private float   lifeTime;                           // How long the popup has been on screen
    public  float   moveSpeed = 5f;                     // How quickly the popup moves
    private string  points = "null";                    // The string for the popup to display
    [SerializeField] private Text   popUpText;          // The Text component
    [SerializeField] private float  maxLifeTime = 1.1f; // How long the popup will remain on screen

    // Accessors
    public string Points { set {    points = value;
                                    popUpText.text = points; }}

    // Use this for initialization ********************************************
    private void Start()
    {
        // Get a reference to the text object
        popUpText = GetComponentInChildren<Text>();
    
    }// END Start

    // Executes every time this object is re enabled ***************************
    private void OnEnable()
    {
        // Reset the variables
        transform.localScale = new Vector3 ( 1f, 1f, 1f);
        lifeTime = 0f;

    }//END OnEnable()

    // Update is called once per frame *****************************************
    void Update()
    {
        // Move verticle scaled by move speed
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Grow larger everyframe
        transform.localScale *= 1.022f;

        // Record time elapsed
        lifeTime += Time.deltaTime;

        // If timer exceeds its maximum lifetime
        if (lifeTime > maxLifeTime)
        {
            // Return the object to the pool
            ScorePopUpPool.Instance.ReturnToPool(this);
        }
        
    }//END Update()
}
