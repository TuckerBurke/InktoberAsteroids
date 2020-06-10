using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Class which spawns smaller asteroids when a large asteroid is       *
//*     destroyed.                                                          *
//*                                                                         *
//*     METHODS                                                             *
//*     void Crumble()                                                      *
//*                                                                         *
//***************************************************************************

public class CrumbleAsteroid : MonoBehaviour
{
    // Local varaibles
    public GameObject[] smallAsteroidPrefabs = new GameObject[3];

    // Crumble the asteroid into smaller asteroids *******************************
    public void Crumble()
    {
        // Get the direction in which large asteroid is traveling
        Vector3 direction = gameObject.GetComponent<AsteroidFlight>().direction;

        // Create an euler angle to pass into instantiate
        float eulerAngle = Mathf.Atan2(direction.y, direction.x);
        eulerAngle *= Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, eulerAngle);

        // Randomly generate the number of crumbles
        int randCrumbles = Random.Range(3, 5);

        // For each crumble
        for (int i = 0; i < randCrumbles; i++)
        { 
            // Determine which asteroid prefab to use
            int randPrefab = Random.Range(0, randCrumbles - 1);

            // Instantiate a small asteroid
            Instantiate(smallAsteroidPrefabs[randPrefab], transform.position, transform.rotation);
        }

    }// END Crumble()
}
