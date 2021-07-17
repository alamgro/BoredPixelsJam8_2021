using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public string unitName;
    public int maxHP;
    public int currentHP;
    public int damage;

    private void Awake()
    {
        CombatManager.heroes.Add(this); //Add this enemy to the enemies list
    }

    private void Start()
    {
    }

    void Update()
    {
        
    }

    private void Attack(Enemy _target)
    {
        //Attack
    }

    public void TakeDamage(int _dmgTaken)
    {
        currentHP -= _dmgTaken;

        //Check if the unit is dead
        if (currentHP <= 0)
            Death();
    }

    private void Death()
    {
        //Logic when dying (animation or something)
    }
}
