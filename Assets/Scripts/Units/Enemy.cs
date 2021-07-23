using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public string unitName;
    public int maxHP;
    public int damage;

    private float currentAttackSpeed;
    private Spells spellToApply;
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
        currentAttackSpeed = Random.Range(1f, 2f);

        StartCoroutine(Attack(currentAttackSpeed));
    }

    void Update()
    {
        ///Debug
        if (Input.GetKeyDown(KeyCode.A))
            Attack(currentAttackSpeed);
    }

    private IEnumerator Attack(float _attackSpeed)
    {
        if (CombatManager.heroes.Count <= 0)
            yield break;

        Hero hero = CombatManager.heroes[Random.Range(0, CombatManager.heroes.Count)];

        yield return new WaitForSecondsRealtime(_attackSpeed);
        //Check if it is not null, just in case another unit killed it before this one
        if (hero != null)
        {
            hero.TakeDamage(damage);

            if(Random.Range(0, 100) < 75)
            {
                int randState = Random.Range(1, 4);
                spellToApply = Spells.Manager.FindSpell(randState);
                hero.SetState(spellToApply.StateApplied);
            }

            //Debug.Log($"{unitName} attacked {hero.unitName}");
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
        CombatManager.enemies.Remove(this);
        CombatManager.Manager.CheckBattleEnd();
        Destroy(gameObject, 0.5f);
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
}
