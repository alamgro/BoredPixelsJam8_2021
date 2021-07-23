using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public int manaAmount;
    public GameObject spellPrefab;
    public SpellHUD spellHUD;

    private Player playerRef;
    private Camera cam;

    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        cam = Camera.main;    
    }

    void Update()
    {
        //Check left click interaction
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                //Check if it is clicking this object
                if(hit.collider.gameObject.Equals(gameObject))
                {
                    //Verify if it is already using the cauldron
                    if(playerRef.GetPlayerState().Equals(PlayerStates.CAULDRON)) 
                    {
                        //It will stop consuming mana if the state is different to CAULDRON
                        playerRef.SetPlayerState(PlayerStates.IDLE); //Back to the Idle state
                        Debug.Log("Caldero apagado.");
                    }
                    else if(playerRef.GetPlayerState().Equals(PlayerStates.IDLE))
                    {
                        //Now is generating mana, so it is on Cauldron state
                        playerRef.SetPlayerState(PlayerStates.CAULDRON);

                        StartCoroutine(playerRef.DrainMana(manaAmount)); //Start generating mana
                        Debug.Log("Caldero encendido.");
                    }

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            GenerateSpellObject();
            //playerRef.SubtractMana(2);
        }
    }

    public void GenerateSpellObject()
    {
        if (spellHUD.GetCurrentIndex() > (spellHUD.elementsPos.Length - 1))
            return;

        GameObject go = Instantiate(spellPrefab, spellHUD.elementsPos[spellHUD.GetCurrentIndex()]); //Instantiate spell on the HUD
        SpellCaster tempSpellCaster = go.GetComponent<SpellCaster>();
        tempSpellCaster.initialPosition = spellHUD.elementsPos[spellHUD.GetCurrentIndex()].position; //Set the initial position
        tempSpellCaster.spellHUD = spellHUD; //Reference to the HUD for the spell to use
        spellHUD.spellObjects.Add(go);

        spellHUD.UpdateIndex(1);

    }

}
