using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellObject : SpellCaster
{
    private Hero targetUnit;
    //AQUÍ PIDRÍA TENER ARRAY DE SPELLS Y APLICARLO POR OBJETO
    private Spells spell; 
    private SpellCaster spellCaster;
    private Vector2 initialPosition;
    private Player player;

    //MANA SE GASTA CON CALDERO. 
    /*
     * CALDERO GENERA POCIONES, MÁXIMO 3.
     * LAS POCIONES CUESTAN MANA
     * PROBAR SISTEMA DE MANA
     * hud de spells con generación. Estará enlazado al caldero
     */

    void Start()
    {
        spellCaster = GetComponent<SpellCaster>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        //Generate a random spell
        int randSpell = Random.Range(0, Spells.Manager.SpellsCount());
        spell = Spells.Manager.FindSpell(randSpell);
        print("Spell: " + spell.StateApplied);
    }

    void Update()
    {
        //print("is touching = " + touchedHero);
    }

    public void ApplySpell()
    {
        player.SubstractMana(spell.ManaCost); //Substract the mana cost to the player
        targetUnit.SetState(spell.StateApplied); //Apply the state to the selected unit
    }

    public Vector2 InitialPosition
    {
        get { return initialPosition; }

        set
        {
            initialPosition = value;
        }
    }

}
