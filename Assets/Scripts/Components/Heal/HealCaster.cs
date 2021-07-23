using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCaster : MonoBehaviour
{
    [HideInInspector]
    public HealPlaceholder placeholder;
    public int healAmount;

    private bool isDragging = false;
    private bool isTouchingHero = false;
    private Camera cam;
    private Hero hero;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        cam = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);
        }
    }

    //Button pressed
    private void OnMouseDown()
    {
        isDragging = true;
        spriteRenderer.sortingOrder = 100;
    }

    //Button release
    private void OnMouseUp()
    {
        isDragging = false;
        spriteRenderer.sortingOrder = 5;
        //Check uf the button is released over a hero
        if (isTouchingHero)
        {
            //Logic to apply some effect
            HealUnit();
            placeholder.SetupPlaceholder();
            Destroy(gameObject);
        }
        else
        {
            //Since is not selecting a hero, just reset the position
            placeholder.ResetPosition(transform); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            //Scale up de object
            hero = collision.GetComponent<Hero>();
            transform.localScale *= 1.5f;
            isTouchingHero = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            //Set object scale to the original size
            hero = null;
            transform.localScale = Vector2.one;
            isTouchingHero = false; //Is not touching a hero
        }
    }
      
    private void HealUnit()
    {
        if (hero)
        {
            print($"{hero.unitName} was healed {healAmount} points");
            hero.IncreaseHP(healAmount);
        }
    }
}
