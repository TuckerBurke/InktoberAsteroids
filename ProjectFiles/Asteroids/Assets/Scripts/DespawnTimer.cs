using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Handles the removal of bullets after time expires                   *
//*                                                                         *
//*     METHODS                                                             *
//*     void Start()                                                        *
//*                                                                         *
//***************************************************************************

public class DespawnTimer : MonoBehaviour
{
    // Local variables
    public bool despawn = true;     // Default despawn value allowing check box
    public float timer = 4.0f;      // Time until objects destruction

	// Use this for initialization **********************************************
	void Start ()
    {
		// If despawn toggle is active
        if (despawn)
        {
            // Then destroy this prefab after set time interval
            Destroy(gameObject, timer);
        }

	}// END Start ()
	
}
