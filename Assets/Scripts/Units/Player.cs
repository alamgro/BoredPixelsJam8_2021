using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This is the player script, which contain the main actions, controls and functionalities of the player mechanics.
 */

public class Player : MonoBehaviour
{
    public int maxMana;

    [SerializeField]
    private int currentMana;
    
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
        manaBar.fillAmount = (float)currentMana / maxMana; //Update unit health bar

        CombatManager.Manager.ShowFeedbackPopup(transform.position, _manaAmount, Color.blue, false);
    }

    public void SubstractMana(int _manaAmount)
    {
        currentMana -= _manaAmount;
        if(currentMana < 0)
        {
            currentMana = 0;
        }
        manaBar.fillAmount = (float)currentMana / maxMana; //Update unit health bar

        CombatManager.Manager.ShowFeedbackPopup(transform.position, _manaAmount, Color.blue, true);
    }

    public int GetMana() { return currentMana; }

    private void RegenarateMana()
    {
        //Logic to regen mana
    }


}
