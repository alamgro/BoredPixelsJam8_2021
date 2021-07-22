using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://forum.unity.com/threads/need-help-with-rpg-spell-ability-system.121605/
public enum States { NONE, DIZZY, SLOW, POISON }

public class Spells : MonoBehaviour
{
    #region SINGLETON MANAGER
    public static Spells Manager { get { return _instance; } }

    private static Spells _instance;
    #endregion

    private int id;
    private string spellName;
    private string description;
    private int manaCost;

    private States stateApplied;

    public Spells(int _id, string _spellName, string _description, States _stateApplied, int _manaCost)
    {
        id = _id;
        spellName = _spellName;
        description = _description;
        stateApplied = _stateApplied;
        manaCost = _manaCost;
    }

    public Spells()
    {
        id = 0;
    }

    //Existing spells
    public List<Spells> spellsDatabase;

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

    public int ManaCost
    {
        get { return manaCost; }

        set
        {
            manaCost = value;
        }
    }

    public int SpellsCount()
    {
        return spellsDatabase.Count;
    }


    public void Awake()
    {
        //if (_instance != null && _instance != this)
        //{
        //    Destroy(this.gameObject);
        //}
        //else
        //{
        //    _instance = this;
        //}
        _instance = this;

        spellsDatabase.Add(new Spells(0, "Normal", "Nothing special here.", States.NONE, 2));
        spellsDatabase.Add(new Spells(1, "Dizzy", "This attack reduces de attack accuracy.", States.DIZZY, 2));
        spellsDatabase.Add(new Spells(2, "Slow Down", "Reduces de attack speed of the target.", States.SLOW, 2));
        spellsDatabase.Add(new Spells(3, "Poison", "Deals a constant amount of damage over 5 seconds.", States.POISON, 2));

    }


}
