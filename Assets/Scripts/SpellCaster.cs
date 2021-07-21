using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    private bool isDragging = false;
    private bool isTouchingHero = false;
    private Camera cam;

    private void OnMouseDown()
    {
        isDragging = true;
    }

    //Button release
    private void OnMouseUp()
    {
        isDragging = false;
        //Check uf the button is released over a hero
        if (isTouchingHero)
        {
            //Logic to apply some effect
            print("Efecto aplicado!");
        }
        Destroy(gameObject);
    }

    void Start()
    {
        cam = Camera.main;
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
            //Scale up de object
            transform.localScale *= 1.5f; 
            isTouchingHero = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            //Set object scale to the original size
            transform.localScale = Vector2.one;
            isTouchingHero = false;
        }
    }
}
