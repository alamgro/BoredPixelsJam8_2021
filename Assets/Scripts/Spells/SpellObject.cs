using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellObject : MonoBehaviour
{
    private Transform targetUnit;
    private Spells spell;

    void Start()
    {
        int randSpell = Random.Range(0, Spells.Manager.SpellsCount());
        //print("Rand num: " + randSpell);

        spell = Spells.Manager.FindSpell(randSpell);
        print("Spell: " + spell.ID);
    }

    void Update()
    {
        
    }
}
