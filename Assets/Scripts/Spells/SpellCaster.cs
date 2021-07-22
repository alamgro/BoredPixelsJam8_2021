using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public Hero touchedHero;

    private bool isDragging = false;
    private Camera cam;
    private SpellObject spellObject;
    private Vector2 initialPosition;

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
        if (touchedHero && spellObject.playerRef.GetMana() >= spellObject.spell.ManaCost)
        {
            //Logic to apply some effect
            spellObject.ApplySpell(); //Apply the spell effect

            print("Efecto aplicado!");
            Destroy(gameObject);
        }
        else
        {
            //Since is not selecting a hero, just reset the position
            ResetPosition(transform);
        }
    }

    void Start()
    {
        spellObject = GetComponent<SpellObject>();
        cam = Camera.main;
        touchedHero = null;
        initialPosition = Vector2.zero;
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

            touchedHero = collision.GetComponent<Hero>(); //Assign the touched hero
            spellObject.targetUnit = touchedHero;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            //Set object scale to the original size
            transform.localScale = Vector2.one;

            touchedHero = null;
            spellObject.targetUnit = null;
        }
    }

    public void ResetPosition(Transform _target)
    {
        _target.position = initialPosition;
    }

}
