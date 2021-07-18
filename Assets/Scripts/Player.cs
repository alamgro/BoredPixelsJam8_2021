using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is the player script, which contain the main actions, controls and functionalities of the player mechanics.
 */

public class Player : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
