using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://forum.unity.com/threads/need-help-with-rpg-spell-ability-system.121605/
public enum States { NORMAL, DIZZY, SLOW, POISON, DAMAGEUP, REGENERATION, SPEEDUP, NONE }

public class Spells : MonoBehaviour
{
    #region SINGLETON MANAGER
    public static Spells Manager { get { return _instance; } }

    private static Spells _instance;
    #endregion

    public Sprite[] spellSprites;

    private int id;
    private string spellName;
    private string description;
    private int manaCost;
    private Sprite icon;

    private States stateApplied;

    public Spells(int _id, string _spellName, string _description, States _stateApplied, int _manaCost, Sprite _icon)
    {
        id = _id;
        spellName = _spellName;
        description = _description;
        stateApplied = _stateApplied;
        manaCost = _manaCost;
        icon = _icon;
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

    public Sprite Icon()
    {
        return icon;
    }

    public void Awake()
    {
        _instance = this;

        spellsDatabase.Add(new Spells(0, "Cleans", "Resets all the current effects.", States.NORMAL, 4, spellSprites[0]));
        spellsDatabase.Add(new Spells(1, "Dizzy", "This attack reduces de attack accuracy.", States.DIZZY, 3, spellSprites[1]));
        spellsDatabase.Add(new Spells(2, "Slow Down", "Reduces the attack speed of the target.", States.SLOW, 2, spellSprites[2]));
        spellsDatabase.Add(new Spells(3, "Poison", "Deals a constant amount of damage over 5 seconds.", States.POISON, 3, spellSprites[3]));
        spellsDatabase.Add(new Spells(4, "Damage up", "Increases the damage of the unit.", States.DAMAGEUP, 3, spellSprites[4]));
        spellsDatabase.Add(new Spells(5, "Regeneration", "Receive HP regeneration for 10 seconds.", States.REGENERATION, 5, spellSprites[5]));
        spellsDatabase.Add(new Spells(6, "Attack speed up", "Increases the attack speed.", States.SPEEDUP, 3, spellSprites[6]));
        spellsDatabase.Add(new Spells(7, "None", "It has no effects. I don't know what else to put here c:", States.NONE, 1, spellSprites[7]));
    }

    public void ApplySpell(Hero _hero, States _state)
    {
        switch (_state)
        {
            case States.NORMAL:
                NormalSpell(_hero);
                break;
            case States.DIZZY:
                DizzySpell(_hero);
                break;
            case States.SLOW:
                StartCoroutine(SlowSpell(_hero));
                break;
            case States.POISON:
                StartCoroutine(PoisonSpell(_hero, 0, 5, 1));
                break;
            case States.DAMAGEUP:
                StartCoroutine(DamageSpell(_hero, 2));
                break;
            case States.REGENERATION:
                StartCoroutine(RegenerationSpell(_hero, 0, 5, 3));
                break;
            case States.SPEEDUP:
                StartCoroutine(SpeedUpSpell(_hero, 0.25f));
                break;
            default:
                break;
        }
    }

    public void NormalSpell(Hero _target)
    {
        _target.SetAttackSpeed(_target.GetOriginalAttackSpeed());
        _target.SetAccuracy(100);
        _target.SetCurrentDamage(_target.GetOriginalDamage());
    }

    public IEnumerator DizzySpell(Hero _target)
    {
        _target.SetAccuracy(50);
        yield return new WaitForSecondsRealtime(5f);
        _target.SetState(States.NORMAL);
        ApplySpell(_target, _target.GetState());
    }

    public IEnumerator SlowSpell(Hero _target)
    {
        _target.SetAttackSpeed(_target.GetAttackSpeed() * 0.5f);
        yield return new WaitForSecondsRealtime(5f);
        _target.SetState(States.NORMAL);
        ApplySpell(_target, _target.GetState());
    }

    public IEnumerator PoisonSpell(Hero _target, int _index, int _maxTicks, int _dps)
    {
        if (_index >= _maxTicks)
        {
            _target.SetState(States.NORMAL);
            ApplySpell(_target, _target.GetState());
            yield break;
        }

        _target.TakeDamage(_dps);
        _index++;
        yield return new WaitForSecondsRealtime(1f);
        StartCoroutine(PoisonSpell(_target, _index, _maxTicks, _dps));
    }

    public IEnumerator DamageSpell(Hero _target, int _damageAmount)
    {
        _target.ModifyCurrentDamage(_target.GetCurrentDamage() + _damageAmount);
        yield return new WaitForSecondsRealtime(5f);
        _target.SetState(States.NORMAL);
        ApplySpell(_target, _target.GetState());
    }

    public IEnumerator RegenerationSpell(Hero _target, int _index, int _maxTicks, int _healAmount)
    {
        if (_index >= _maxTicks)
        {
            _target.SetState(States.NORMAL);
            ApplySpell(_target, _target.GetState());
            yield break;
        }

        _target.IncreaseHP(_healAmount);
        _index++;
        yield return new WaitForSecondsRealtime(2f);
        StartCoroutine(RegenerationSpell(_target, _index, _maxTicks, _healAmount));
    }

    public IEnumerator SpeedUpSpell(Hero _target, float _timeReduction)
    {
        _target.SetAttackSpeed(_target.GetAttackSpeed() - _timeReduction);

        yield return new WaitForSecondsRealtime(10f);
        _target.SetState(States.NORMAL);
        ApplySpell(_target, _target.GetState());
    }

}
