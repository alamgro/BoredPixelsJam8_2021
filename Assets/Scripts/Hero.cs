using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
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
        //Check if it is not null, just in case another unit killed it before this one
        if (enemy)
        {
            enemy.TakeDamage(damage);
            Debug.Log($"{unitName} attacked {enemy.unitName}");
        }

        StartCoroutine(Attack());
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
        CombatManager.heroes.Remove(this);
        Destroy(gameObject, 1.0f);

    }
}
