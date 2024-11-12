using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    
    [SerializeField] private string newGameLevel; //creates serializefield, meaning editable in uinty editor, with designation Level 1 (the designation should be a level that exists)
    public void startGameButton()
    {
        SceneManager.LoadScene(newGameLevel); //this takes the value Level 1 and sends the player to level 1 (or whatever destination is inside the method LoadScene
        //WARNING besure the button has on click with whatever element has this script to ensure it occurs
    }
   

}
