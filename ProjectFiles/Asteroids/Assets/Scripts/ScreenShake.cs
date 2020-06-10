using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Simple parameterized screen shake (no rotation)                     *
//*                                                                         *
//*     METHODS                                                             *
//*     Shake(float, float)                                                 *
//*                                                                         *
//***************************************************************************

public class ScreenShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        // Store original posiition
        Vector3 originalPosition = transform.localPosition;

        // Initialize a timer
        float elapsed = 0.0f;

        // While time is less than the duration
        while (elapsed < duration)
        {
            // Choose a random offset
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            // Transform cameras position
            transform.localPosition = new Vector3(x, y);

            // Increment time
            elapsed += Time.deltaTime;

            // Sync to update
            yield return null;
        }

        // Recenter camera
        transform.localPosition = originalPosition;
    
    }// END Shake()
}
