using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShieldTank : MonoBehaviour
{
    public GameObject tankSpawn;
    public GameObject tank;
   // BoxCollider2D coll;
    Vector2 spawnPosition;
    Quaternion spawnRotation = Quaternion.identity;
   public bool zoned = false;
    ChargePoints cP; //inheriting information from the ChargePoints class, will be for chargePoint value
   [SerializeField] int maxTanks = 1; // Maximum number of enemies that can be spawned
    [HideInInspector] public int tankCounter = 0; // Counter for the number of tanks spawned
    //[SerializeField] private LayerMask foundGround;

    // Start is called before the first frame update
    void Start()
    {
        cP = FindObjectOfType<ChargePoints>(); // instantiates cP as ChargePoints
       // coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TankButton()
    {
        
        if (cP.chargePoints >= 4 && tankCounter < maxTanks)
        {
            cP.chargePoints -= 4;
            spawnPosition = tankSpawn.transform.position; // determines the spawnPosition based on BulletSpawn object location
            Instantiate(tank, spawnPosition, spawnRotation); //creates and "instantiates" the bullet in world
           tankCounter++; // increases the tank counter, maxTanks set to 1 only letting 1 tank in at a time
            Debug.Log("unlocking the Shield Tank for 4");
        }
        else { Debug.Log("Not enough points"); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Base"))
        { 
            zoned = true; //indicates it met the base trigger making it destroyeable
            Debug.Log("zoned");
            gameObject.layer = 9; // changes the layer to the pink layer, enemy samurai's attack the pink layer
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Ground") && gameObject.layer !=9 )
        {
            gameObject.layer = 11;
        }
    }

   // private bool Ground()
   // {
       // if (gameObject.layer != 9 || gameObject.layer !=11)
       // {
         //   return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 1f, foundGround);

       // }
       // else {  return false; }
 //   }
}
