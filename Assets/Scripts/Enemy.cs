using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string unitName;
    public int maxHP;
    public int currentHP;
    public int damage;

    private void Awake()
    {
        CombatManager.enemies.Add(this); //Add this enemy to the enemies list
    }

    private void Start()
    {
    }

    void Update()
    {

    }

    private void Attack(Hero _target)
    {

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
