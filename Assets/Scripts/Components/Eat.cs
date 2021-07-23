using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public int manaAmount;

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
                if (hit.collider.gameObject.Equals(gameObject))
                {
                    //Verify if it is already using the cauldron
                    if (playerRef.GetPlayerState().Equals(PlayerStates.RESTING))
                    {
                        //It will stop generating mana if the state is different to CAULDRON
                        playerRef.SetPlayerState(PlayerStates.IDLE); //Back to the Idle state
                        Debug.Log("De vuelta a pelear.");
                    }
                    else if (playerRef.GetPlayerState().Equals(PlayerStates.IDLE) || playerRef.GetPlayerState().Equals(PlayerStates.CAULDRON))
                    {
                        //Now is generating mana, so it is on Cauldron state
                        playerRef.SetPlayerState(PlayerStates.RESTING);

                        StartCoroutine(playerRef.RegenerateMana(manaAmount)); //Start generating mana
                        Debug.Log("Caldero encendido.");
                    }

                }
            }
        }
    }
}
