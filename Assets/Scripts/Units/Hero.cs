using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public string unitName;
    public int maxHP;

    private int originalDamage;
    private int currentDamage;
    private float originalAttackSpeed;
    private float currentAttackSpeed;
    private int accuracy = 100;
    [SerializeField]
    private States currentState;
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
        originalAttackSpeed = Random.Range(0.75f, 2.0f);
        currentAttackSpeed = originalAttackSpeed;
        originalDamage = Random.Range(1, 4);
        currentDamage = originalDamage;
        StartCoroutine(Attack(currentAttackSpeed));
    }

    void Update()
    {
        ///Debug
        if (Input.GetKeyDown(KeyCode.A))
            TakeDamage(1);
    }

    private IEnumerator Attack(float _attackSpeed)
    {
        if (CombatManager.enemies.Count <= 0)
            yield break;
        
        Enemy enemy = CombatManager.enemies[Random.Range(0, CombatManager.enemies.Count)];

        yield return new WaitForSecondsRealtime(_attackSpeed);
        //Check if it is not null, just in case another unit killed it before this one
        if (enemy)
        {
            //If the randProbability is lower than te accuracy, then it hits the attack
            int randProbability = Random.Range(0, 101);
            if(randProbability < accuracy)
                enemy.TakeDamage(currentDamage);
            //Debug.Log($"{unitName} attacked {enemy.unitName}");
        }
        StartCoroutine(Attack(_attackSpeed));
    }

    public void TakeDamage(int _dmgTaken)
    {
        currentHP -= _dmgTaken; //Apply damage
        healthBar.fillAmount = (float)currentHP / maxHP; //Update unit health bar

        CombatManager.Manager.ShowFeedbackPopup(transform.position, _dmgTaken, Color.red, true); //Instantiate damage popup

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

    public int GetHP() { return currentHP; }

    public void SetHP(int _targetHP)
    {
        currentHP = _targetHP;

        if (currentHP > maxHP)
            currentHP = maxHP;

        healthBar.fillAmount = (float)currentHP / maxHP; //Update unit health bar
    }

    public void IncreaseHP(int _HPAmount)
    {
        currentHP += _HPAmount;

        if (currentHP > maxHP)
            currentHP = maxHP;

        healthBar.fillAmount = (float)currentHP / maxHP; //Update unit health bar

        CombatManager.Manager.ShowFeedbackPopup(transform.position, _HPAmount, Color.green, false); //Instantiate popup
    }

    public States GetState() { return currentState; }

    public void SetState(States _currentState)
    {
        currentState = _currentState;
        Spells.Manager.ApplySpell(this, currentState); //Apply the effects of the current state
    }

    public float GetAttackSpeed() { return currentAttackSpeed; }

    public void SetAttackSpeed(float _attackSpeed)
    {
        currentAttackSpeed = _attackSpeed;

        //Max attack speed
        if (currentAttackSpeed < 0.15f)
            currentAttackSpeed = 0.15f;
    }

    public float GetOriginalAttackSpeed() { return originalAttackSpeed; }

    public float GetAccuracy() { return accuracy; }

    public void SetAccuracy(int _accuracy) { 
        accuracy = _accuracy;

        if (accuracy > 100)
            accuracy = 100;
        else if (accuracy < 0)
            accuracy = 0;
    }

    public int GetOriginalDamage() { return originalDamage; }

    public int GetCurrentDamage() { return currentDamage; }

    public void SetCurrentDamage(int _damageAmount)
    {
        currentDamage = _damageAmount;

        if (currentDamage > 100)
            currentDamage = 100;
        else if (currentDamage < 1)
            currentDamage = 1;
    }

    public void ModifyCurrentDamage(int _damageAmount)
    {
        currentDamage += _damageAmount;

        if (currentDamage > 100)
            currentDamage = 100;
        else if (currentDamage < 1)
            currentDamage = 1;
    }

}
