using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellObject : MonoBehaviour
{
    private Transform targetUnit;


    void Start()
    {
        print("Description: " + Spells.Manager.FindSpell(2).Description);
    }

    void Update()
    {
        
    }
}
