using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDad : MonoBehaviour
{
    public GameManager GameManager; //referencing GameManager script
    public Animator animator; // Reference to the Animator component
    

    private void Start()
    {
      

    }

    void Update()
    {
        // Check if MyMethod has been called
        if (GameManager != null && GameManager.isMethodCalled) //when the GameManager isn't not performing anything and if is method call true
        {
            TriggerAnimation();
            GameManager.isMethodCalled = false; // Reset the flag to avoid repeated calls
        }
    }

    void TriggerAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Spawn_Animation"); // triggers the trigger Spawn_Animation which is attached to spacedadPoint.
            //Debug.Log("Animation triggered!");  //Debug to check if action is performing

            //this whole set of code is to have Space dad point forward whenever units are spawned. By having it attached to isMethodCalled
            // if I make other units all I have to do to to make that anim perform is have the spawn trigger isMethodCalled be true
        }
    }

}

//Adding for GitHub learning and tutorial

