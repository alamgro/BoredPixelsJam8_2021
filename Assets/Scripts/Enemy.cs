using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public string unitName;
    public int maxHP;
    public int damage;
    [SerializeField]
    private int currentHP;
    [SerializeField]
    private Image healthBar;

    private void Awake()
    {
        CombatManager.enemies.Add(this); //Add this enemy to the enemies list
    }

    private void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {

    }

    private void Attack()
    {
        Hero hero = CombatManager.heroes[Random.Range(0, CombatManager.heroes.Count)];
        hero.TakeDamage(damage);
        Debug.Log($"{unitName} attacked {hero.unitName}");
    }

    public void TakeDamage(int _dmgTaken)
    {
        currentHP -= _dmgTaken; //Apply damage

        healthBar.fillAmount = (float)currentHP / maxHP; //Update unit health bar

        //Check if the unit is dead
        if (currentHP <= 0)
            Death();
    }

    private void Death()
    {
        //Logic when dying (animation or something)
        CombatManager.enemies.Remove(this);
        Destroy(gameObject, 1.0f);
    }
}
