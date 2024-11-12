using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTrigger : MonoBehaviour
{
    // List to store detected GameObjects
    public List<GameObject> detectedObjects = new List<GameObject>();
    // Start is called before the first frame update

    private void Update()
    {
        OnDestroy(); // This will keep the list free of null references in each frame
    }

    // Detect when another GameObject enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
        {
        // Check if the colliding object is GameObject A (you can check by tag, name, or component)
        if (other.gameObject.tag == "Enemy Unit") // Assuming "GameObjectA" is the tag for A
        {
            // Add the detected GameObject to the list
            detectedObjects.Add(other.gameObject);
            Debug.Log("SAMURAI TRIGGERS");
                //Debug.Log($"{other.gameObject.name} added to the list.");
            }
        }
    public void OnDestroy()
    {
       detectedObjects.RemoveAll(item => item == null);
       //removes all all null items in list
    }

}
