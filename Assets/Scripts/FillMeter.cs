using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FillMeter : MonoBehaviour
{
    // Regions help to visually organize your code into sections.
    #region Variables
    GameManager gm;
    ChargePoints cP; //inheriting information from the ChargePoints class, will be for chargePoint value
    

    // Headers are like titles for the Unity Inspector.
    [Header("Fill Meter")]
    // SerializeField allows you to see private variables in the inspector while keeping them private
    [SerializeField] Slider slider;

    /* In C# if you do not specify a variable modifier (i.e. public, private, protected), it defaults to private
    The private variable modifier stops other scripts from accessing those variables */
    bool canSpawn = false; // Determines if the player can spawn a samurai
  public  bool goGo = false; // boolion representing Adrenaline being active or not
    int maxVal = 5; //internal Slider max value
    int minVal = 0;  // internal slider min value
    int goVal = 1; //slider max value while adrenaline power up is active

    #endregion // Marks the end of the region

    #region Unity Methods
    // Start is called before the first frame update
    private void Start()
    {
        gm = GameManager.Instance; // Sets our local reference to the GameManager instance
        cP = FindObjectOfType<ChargePoints>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Decreases the slider value over time
        if (slider.value > minVal)
        {
            slider.value -= Time.deltaTime; //time interval in seconds since last frame to the current
        }
        if (slider.value <= minVal)
        {
            canSpawn = true; // Enables the player to spawn a samurai
        }
    }
    #endregion

    #region Custom Methods
    /// <summary>
    /// Spawns a samurai if the cooldown is over and the player presses the button
    /// </summary>
    public void SpawnSamurai()
    {

        if (goGo == true)
        {
           
            if (!canSpawn)
            {
                return;
            }

            // If the GameManager instance is null, set it to the GameManager instance
            if (gm == null)
            {
                gm = GameManager.Instance;
            }

            Debug.Log("Spawned Samurai");

            gm.SpawnSamurai();
            slider.value = goVal; // Resets the slider value to the duration for adrenaline powerup, reducing cooldown time
            canSpawn = false; // Disables the player from spawning another samurai
        }
        // If the player can't spawn a samurai, exit the method
        else if (goGo == false) 
        {
            if (!canSpawn)
            {
                return;
            }

            // If the GameManager instance is null, set it to the GameManager instance
            if (gm == null)
            {
                gm = GameManager.Instance;
            }

            Debug.Log("Spawned Samurai");

            gm.SpawnSamurai();
            slider.value = slider.maxValue; // Resets the slider value
            canSpawn = false; // Disables the player from spawning another samurai
        }
    }

    public void Adrenaline() //power up method engaged from on click event, see adrenaline button
    {
        if (cP.chargePoints >= 9)
        {
            cP.chargePoints -= 9;
            goGo = true;
            StartCoroutine(CoolDown()); //coroutine utilized for Adrenaline power up duration

        }
        else { Debug.Log("Not enough points"); }
    }

    IEnumerator CoolDown()
    {
        Debug.Log("coroutine started");
        yield return new WaitForSeconds(6); //waits 6 seconds before resetting goGo to false and slider.value to maxVal resetting back to standard use
        goGo = false;
        slider.value = maxVal;

    }
    #endregion
}
