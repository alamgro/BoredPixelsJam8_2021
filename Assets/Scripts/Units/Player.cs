using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This is the player script, which contain the main actions, controls and functionalities of the player mechanics.
 */

public class Player : MonoBehaviour
{
    private int currentMana;
    private int maxMana;
    
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

    public void AddMana(int _manaAmount)
    {
        currentMana += _manaAmount;
        if(currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }
    
    public void SubstractMana(int _manaAmount)
    {
        currentMana -= _manaAmount;
        if(currentMana < 0)
        {
            currentMana = 0;
        }
    }

    public int GetMana() { return currentMana; }

    private void RegenarateMana()
    {
        //Logic to regen mana
    }


}
