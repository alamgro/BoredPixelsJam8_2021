using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public string unitName;
    public int maxHP;
    public int damage;

    private int currentHP;

    private void Awake()
    {
        CombatManager.heroes.Add(this); //Add this enemy to the enemies list
    }

    private void Start()
    {
        currentHP = maxHP;
        StartCoroutine(Attack());
    }

    void Update()
    {
        ///Debug
        if (Input.GetKeyDown(KeyCode.A))
            Attack();
    }

    private IEnumerator Attack()
    {
        if (CombatManager.enemies.Count <= 0)
            yield break;
        
        Enemy enemy = CombatManager.enemies[Random.Range(0, CombatManager.enemies.Count)];
        yield return new WaitForSecondsRealtime(1.0f);
        enemy.TakeDamage(damage);
        Debug.Log($"{unitName} attacked {enemy.unitName}");
        StartCoroutine(Attack());
    }

    public void TakeDamage(int _dmgTaken)
    {
        
    }

    private void Death()
    {
        //Logic when dying (animation or something)
        CombatManager.heroes.Remove(this);
        Destroy(gameObject, 1.0f);

    }
}
