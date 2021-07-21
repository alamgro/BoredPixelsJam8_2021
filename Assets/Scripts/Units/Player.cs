using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This is the player script, which contain the main actions, controls and functionalities of the player mechanics.
 */

public class Player : MonoBehaviour
{
    public int currentMana;
    public int maxMana;

    [SerializeField]
    private Image manaBar;

    void Start()
    {
        currentMana = maxMana;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void RegenarateMana()
    {
        //Logic to regen mana
    }

}