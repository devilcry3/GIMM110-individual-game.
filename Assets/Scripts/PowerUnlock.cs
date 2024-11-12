using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PowerUnlock : MonoBehaviour
{
    ChargePoints cP; //inheriting information from the ChargePoints class, will be for chargePoint value
    public GameObject BulletSpawn;
    public GameObject bullet;
    Vector2 spawnPosition;
    Quaternion spawnRotation = Quaternion.identity;
   
   public void Start()
    {
      cP = FindObjectOfType<ChargePoints>(); // instantiates cP as ChargePoints
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TowerGun()
    {
        if (cP.chargePoints >= 8)
        {
            cP.chargePoints -= 8;
          spawnPosition = BulletSpawn.transform.position; // determines the spawnPosition based on BulletSpawn object location
            Instantiate(bullet, spawnPosition, spawnRotation); //creates and "instantiates" the bullet in world
            Debug.Log("unlocking the Tower Gun for team defense");
        }
        else { Debug.Log("Not enough points"); }
    }
}
