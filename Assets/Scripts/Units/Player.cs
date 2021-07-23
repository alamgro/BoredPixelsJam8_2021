using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This is the player script, which contain the main actions, controls and functionalities of the player mechanics.
 */
public enum PlayerStates { IDLE, CAULDRON, CASTING, RESTING}
public class Player : MonoBehaviour
{
    public int maxMana;

    private PlayerStates playerState;
    private int currentMana;
    public Image manaBar;


    void Start()
    {
        playerState = PlayerStates.IDLE;
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

    public void SubtractMana(int _manaAmount)
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

    public PlayerStates GetPlayerState() { return playerState; }

    public void SetPlayerState(PlayerStates _state)
    {
        playerState = _state;
    }

    //Añade x mana cada cierto tiempo
    public IEnumerator DrainMana(int _manaAmount)
    {
        if (!playerState.Equals(PlayerStates.CAULDRON))
            yield break;

        SubtractMana(_manaAmount);
        yield return new WaitForSecondsRealtime(1.5f);
        StartCoroutine(DrainMana(_manaAmount));
    }

}
