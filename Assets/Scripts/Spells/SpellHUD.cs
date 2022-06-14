using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHUD : MonoBehaviour
{
    public Transform[] elementsPos = new Transform[3];
    public List<GameObject> spellObjects;
    private int currentIndex = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCurrentIndex() { return currentIndex; }

    public void UpdateIndex(int _amount)
    {
        currentIndex += _amount;
    }

    public void ReorderHUD()
    {
        for(int i = 0; i < spellObjects.Count; i++)
        {
            spellObjects[i].GetComponent<SpellCaster>().initialPosition = elementsPos[i].position;
            spellObjects[i].transform.SetParent(elementsPos[i]); //Set the correct parent
            spellObjects[i].transform.position = elementsPos[i].position;
        }
    }
}
