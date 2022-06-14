using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellCaster : MonoBehaviour
{
    public Hero touchedHero;
    public Vector2 initialPosition;
    public SpellHUD spellHUD;
    public GameObject toolTip;
    public TextMeshProUGUI textToolTipUI;

    private bool isDragging = false;
    private Camera cam;
    private SpellObject spellObject;
    private SpriteRenderer spriteRenderer;

    //Button was pressed 
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
        //Check uf the button is released over a hero and the mana
        if (touchedHero && spellObject.playerRef.GetMana() >= spellObject.spell.ManaCost)
        {
            spellObject.ApplySpell(); //Apply the spell effect
            spellHUD.spellObjects.Remove(gameObject); //Remove the object from the HUD list
            spellHUD.UpdateIndex(-1); //Reduce de current index 

            spellHUD.ReorderHUD(); //Reorder de HUD
            print("Efecto aplicado!");
            Destroy(gameObject);
        }
        else
        {
            //Since is not selecting a hero, just reset the position
            ResetPosition(transform);
        }
    }

    private void OnMouseEnter()
    {
        toolTip.SetActive(true);
    }

    private void OnMouseExit()
    {
        toolTip.SetActive(false);
    }

    void Start()
    {
        spellObject = GetComponent<SpellObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cam = Camera.main;
        touchedHero = null;

        textToolTipUI.text = spellObject.spell.SpellName + ": " + spellObject.spell.Description;
        toolTip.SetActive(false);

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
