using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public Hero touchedHero;

    private bool isDragging = false;
    private Camera cam;
    private SpellObject spellObject;

    //Button was pressed 
    private void OnMouseDown()
    {
        isDragging = true;
    }

    //Button release
    private void OnMouseUp()
    {
        isDragging = false;
        //Check uf the button is released over a hero
        if (touchedHero)
        {
            //Logic to apply some effect
            spellObject.ApplySpell(); //Apply the spell effect

            print("Efecto aplicado!");
        }
        Destroy(gameObject);
    }

    void Start()
    {
        spellObject = GetComponent<SpellObject>();
        cam = Camera.main;
        touchedHero = null;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            //Scale up object
            transform.localScale *= 1.5f;

            touchedHero = collision.GetComponent<Hero>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            //Set object scale to the original size
            transform.localScale = Vector2.one;

            touchedHero = null;
        }
    }
}
