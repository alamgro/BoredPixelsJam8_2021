using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is the player script, which contain the main actions, controls and functionalities of the player mechanics.
 */

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
