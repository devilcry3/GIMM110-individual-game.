using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScreenPanel : MonoBehaviour
{

    float timer = 0;
    [SerializeField] GameObject screen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3.5f)
        {
            screen.SetActive(true);
        }
       
    }
}
