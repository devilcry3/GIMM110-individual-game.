using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Regions help to visually organize your code into sections.
    #region Variables
    // Static variables are shared across all instances of a class
    public static GameManager Instance { get; private set; } // Singleton pattern that allows you to access the GameManager instance from other scripts
    
    public bool isMethodCalled = false; //flags to track if a method was called or not

    // Headers are like titles for the Unity Inspector.
    [Header("User Spawns")]
   
    // SerializeField allows you to see private variables in the inspector while keeping them private
    /* In C# if you do not specify a variable modifier (i.e. public, private, protected), it defaults to private
    The private variable modifier stops other scripts from accessing those variables */
    [SerializeField] GameObject samurai;
    [SerializeField] GameObject userSpawnPos;

    [Header("Enemy Spawns")]
    [SerializeField] GameObject enemySamurai;
    [SerializeField] GameObject enemySpawnPos;
    [SerializeField] float timeToSpawn = 4f; // Time in seconds to spawn an enemy
    [SerializeField] int maxEnemies = 15; // Maximum number of enemies that can be spawned

    // HideInInspector hides the variable from the inspector, but allows other scripts to access it if needed
    [HideInInspector] public int enemyCounter = 0; // Counter for the number of enemies spawned
    #endregion // Marks the end of the region

    #region Unity Methods
    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // If the instance is null, set it to this instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroys the duplicate instance if it exists
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnEnemy()); // Starts the coroutine to spawn enemies
        //A coroutine is a method that can pause execution and return control to
        //Unity but then continue where it left off on the following frame.
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            timeToSpawn = 2f; // Time in seconds to spawn an enemy
            int maxEnemies = 25;
        }
    }
    #endregion

    #region Custom Methods
    /// <summary>
    /// Spawns an enemy samurai at regular intervals
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnEnemy()
    {
        while (true) // Infinite loop to keep spawning enemies
        {
            if (enemyCounter < maxEnemies)
            {
                // Spawns an enemy samurai at the enemy spawn position
                GameObject spawnedEnemy = Instantiate(enemySamurai, enemySpawnPos.transform.position, Quaternion.identity, enemySpawnPos.transform);
                spawnedEnemy.transform.Rotate(0, 180, 0); // Rotates the enemy to face the user
                enemyCounter++;
            }

            yield return new WaitForSeconds(timeToSpawn); // Waits for the specified time before spawning another enemy
        }
    }

    /// <summary>
    /// Spawns a samurai at the user's spawn position
    /// </summary>
    public void SpawnSamurai()
    {
        // Spawns a samurai at the user spawn position
        Instantiate(samurai, userSpawnPos.transform.position, Quaternion.identity, userSpawnPos.transform);

        isMethodCalled = true;
    }
    #endregion
}
