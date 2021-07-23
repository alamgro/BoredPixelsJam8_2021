using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellObject : MonoBehaviour
{
    [HideInInspector]
    public Hero targetUnit;
    [HideInInspector]
    public Player playerRef;
    [HideInInspector]
    public Spells spell;

    //AQUÍ PIDRÍA TENER ARRAY DE SPELLS Y APLICARLO POR OBJETO

    //MANA SE GASTA CON CALDERO. 
    /*
     * CALDERO GENERA POCIONES, MÁXIMO 3.
     * LAS POCIONES CUESTAN MANA
     * PROBAR SISTEMA DE MANA
     * HUD de spells con generación. Estará enlazado al caldero
     * APLICAR EL CAMBIO DE MANA EN LA BARRA
     */

    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetUnit = null;

        //Generate a random spell
        int randSpell = Random.Range(0, Spells.Manager.SpellsCount());
        spell = Spells.Manager.FindSpell(randSpell);
        //print("Spell: " + spell.StateApplied);
    }

    void Update()
    {
        //print("is touching = " + touchedHero);
    }

    public void ApplySpell()
    {
        if(playerRef)
            playerRef.SubtractMana(spell.ManaCost); //Substract the mana cost to the player
        if (targetUnit)
            targetUnit.SetState(spell.StateApplied); //Apply the state to the selected unit
    }

}
