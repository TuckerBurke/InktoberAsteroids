using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***************************************************************************
//*                                                                         *
//*     Generic Template class to represent a pool of similar objects       *
//*     which are actually referred to by one of their components           *
//*                                                                         *
//*     METHODS                                                             *
//*     T Get()                                                             *
//*     void ReturnToPool(T)                                                *
//*     void AddObjects(int)                                                *
//*                                                                         *
//***************************************************************************

public abstract class ObjectPool<T> : MonoBehaviour where T : Component
{
    // The type of object stored in the pool
    [SerializeField] private T prefab;

    // Accessors (private singleton setter)
    public static ObjectPool<T> Instance { get; private set; }

    // The actual pool
    private Queue<T> objects = new Queue<T>();

    // Generic singleton pattern, prevents overwrite
    private void Awake() => Instance = this;

    // Fetches an object from the pool
    public T Get()
    {
        // If the pool is empty
        if (objects.Count == 0)

            // Add an object to it
            AddObjects(1);

        // Remove the first object from queue
        return objects.Dequeue();

    }// END Get()

    // Returns a USED object to the pool
    public void ReturnToPool (T objectToReturn)
    {
        // Deactivate object
        objectToReturn.gameObject.SetActive(false);

        // Reset to base size
        objectToReturn.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        // Put the object back into the queueu
        objects.Enqueue(objectToReturn);

    }// END ReturnToPool()

    // Adds a NEW object to the pool
    public void AddObjects(int count)
    {
        // Create object
        var newObject = GameObject.Instantiate(prefab);

        // Enable it
        newObject.gameObject.SetActive(false);

        // Add to queueu
        objects.Enqueue(newObject);

    }// END AddObjects()
}
