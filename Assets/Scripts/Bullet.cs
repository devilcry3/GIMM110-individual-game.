using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 10.0f;
    public float interval = 1.5f; // represents 5 seconds interval
    private float timer = 0f; //creates a float to hold the timer count
    public float intervalDuration = 10f; // represents how long the bullet lasts
    private float timerDuration = 0f; //creates a float to hold the timer count for bullet duration
    public List<GameObject> enemyList = new List<GameObject>();
    TrackTrigger trigger; //calling class TrackTrigger
    Health attack; // calls health script
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] LayerMask enemyLayer; //looks for a set Layer, set to Red layer (the enemies layer) in unitys hub
    GameObject enemy; //Serialize to for debug perpuses


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trigger = FindObjectOfType<TrackTrigger>(); //instantiates trigger as a connection to TrackTrigger
        attack = FindObjectOfType<Health>();
    }

    private void FixedUpdate()
    {
        #region Damage Timer

        timer += Time.fixedDeltaTime;

        // Check if 5 seconds (interval) have passed
        if (timer >= interval)
        {
            timer = 0;
            AttackEnemy(); // Calls the AttackEnemy method
        }
        #endregion


        #region Bullet Instance Duration

        timerDuration += Time.fixedDeltaTime;
        if (timerDuration >= intervalDuration)
        {
            timerDuration = 0;
            Destroy(gameObject);
        }
    }
    #endregion



    #region Detection and Movement scripts (located in Update)
    void Update()
    {
        if (trigger.detectedObjects != null && trigger.detectedObjects.Count > 0) // Check if the list is not null and contains elements
        {
            enemyList = trigger.detectedObjects; // Sync enemyList with detectedObjects list

            // Ensure enemyList has at least one element before accessing the first item
            if (enemyList.Count > 0)
            {
                enemy = enemyList[0]; // Access the first enemy in the list
                rb.simulated = true; //simulated true means the rigidbody is simulated and physics work

                if (enemy != null)
                {
                    Vector2 moveDirection = (enemy.transform.position - transform.position).normalized; // Calculate move direction
                    rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed); // Move towards enemy
                    //Debug.Log(enemy.transform.position);
                }
                else
                {
                    rb.simulated = false; // Stop movement if enemy is null, by turning off rigidbody simulation
                    //this prevents the bullet from being affected by physic forces
                }
            }
        }
        else
        {
           rb.simulated = false; // Stop movement if no objects are detected
            //Debug.Log("nogo");
        }
    }
    #endregion

    #region Bullet Damage scripts
    private void AttackEnemy()
    {
        bool inRange;
        // Casts a ray to check if an enemy is in range, utilizes the player or enemy layer to determine if a unit or base is nearby
        RaycastHit2D enemyCheck = Physics2D.Raycast(transform.position, transform.right, attackRange, enemyLayer);

        // If there is no enemy in range, set the inRange parameter to false and exit the method
        if (enemyCheck.collider == null)
        {
            inRange = false;
            return;
        }
        else
        {
            inRange = true;
            enemy = enemyCheck.collider.gameObject;
        }
        // If there is an enemy in range, set the inRange parameter to true and set the enemy object

        if (inRange == true)
        {
            int bulletDamage = 10;
            enemy.TryGetComponent(out Health enemyHealth); // Tries to get the Health component from the enemy object
            if (enemyHealth == null)
            {
                Debug.LogWarning("This collider does not have a health script");
                return;
            }
            else
                enemyHealth.TakeDamage(bulletDamage); // Calls the TakeDamage method from the Health script
        }
    }
}
#endregion