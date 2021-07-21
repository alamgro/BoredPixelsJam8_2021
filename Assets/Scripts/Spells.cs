using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://forum.unity.com/threads/need-help-with-rpg-spell-ability-system.121605/

public class Spells : MonoBehaviour
{
    #region SINGLETON MANAGER
    public static Spells Manager { get { return _instance; } }

    private static Spells _instance;
    #endregion

    private int id;
    private string spellName;
    private string description;

    public enum States { NONE, DIZZY, SLOW, POISON }
    public States stateApplied;

    public Spells(int _id, string _spellName, string _description, States _stateApplied)
    {
        id = _id;
        spellName = _spellName;
        description = _description;
        stateApplied = _stateApplied;
    }

    public Spells()
    {
        id = 0;
    }

    //Existing spells
    private Spells[] spellsDatabase;

    //public Spells[] spellsDatabase =
    //{
    //    new Spells(0, "Normal", "A normal attack", States.NONE),
    //    new Spells(1, "Dizzy", "This attack reduces de attack accuracy", States.DIZZY),
    //    new Spells(2, "Slow Down", "Reduces de attack speed of the target", States.SLOW),
    //    new Spells(3, "Poison", "Deals a constant amount of damage over 5 seconds", States.POISON),
    //};

    //FALTA PROBAR LOS EFECTOS


    //Call this to retrieve spell data
    public Spells FindSpell(int _ID)
    {
        return spellsDatabase[_ID];
    }

    public int ID
    {
        get { return id; }

        set
        {
            id = value;
        }
    }

    public string SpellName
    {
        get { return spellName; }
            
        set
        {
            spellName = value;
        }
    }

    public string Description
    {
        get { return description; }

        set
        {
            description = value;
        }
    }

    public States StateApplied
    {
        get { return stateApplied; }

        set
        {
            stateApplied = value;
        }
    }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        spellsDatabase[0] = new Spells(0, "Normal", "A normal attack", States.NONE);
        spellsDatabase[1] = new Spells(1, "Dizzy", "This attack reduces de attack accuracy", States.DIZZY);
        spellsDatabase[2] = new Spells(2, "Slow Down", "Reduces de attack speed of the target", States.SLOW);
        spellsDatabase[3] = new Spells(3, "Poison", "Deals a constant amount of damage over 5 seconds", States.POISON);
    }


}
