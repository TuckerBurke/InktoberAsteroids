using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     This component generates stars from the poo at given intervals      *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*     void Update()                                                       *
//*                                                                         *
//***************************************************************************

public class StarCaller : MonoBehaviour
{
    [SerializeField] Star star;     // The individual, unpooled star scipt
    private float timer;          // Tracks time elapsed

    // Start is called before the first frame update *************************
    void Start()
    {
        // Grab reference to script
        star = GetComponent<Star>();

        // Create 10 stars to start
        for (int i = 0; i < 10; i++)
        {
            // Call generate from or for pool
            star.Summon();
        }

    }// END Start()

    // Update is called once per frame **************************************
    void Update()
    {
        // increment timer
        timer += Time.deltaTime;

        // Every 3rd of a second
        if (timer >= 0.1f)
        {
            // Create a new star
            GetComponent<Star>().Summon();

            // Reset timer
            timer = 0f;
        }
        
    }// END Update()
}
