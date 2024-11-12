using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // called the text mesh pro library

public class ChargePoints : MonoBehaviour
{
    public float interval = 5f; // represents 5 seconds interval
    private float timer = 0f; //creates a float to hold the timer count
    public int chargePoints = 0;
    [SerializeField] private TextMeshProUGUI pointText; //serialized field specifically for a TextMeshProUI, is not interchangeable with legacy text box
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        pointText.text = "Charge Points: " + chargePoints; //updates the Textmeshpro text box with the curretn chargePoints value
    }

   

    // FixedUpdate is called every fixed frame-rate frame
    public void FixedUpdate()
    {
        // Increase timer by fixedDeltaTime
        timer += Time.fixedDeltaTime;

        // Check if 5 seconds (interval) have passed
        if (timer >= interval)
        {
            // Reset the timer
            timer = 0f;

            // increases chargePoints value once a fixed 5 second time has passed
            chargePoints+= 2;

            // Log the new value (or perform any other action)
            Debug.Log("Value increased: " +chargePoints);
        }
    }
}
