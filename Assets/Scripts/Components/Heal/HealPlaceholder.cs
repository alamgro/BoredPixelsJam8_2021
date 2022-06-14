using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealPlaceholder : MonoBehaviour
{
    public float cooldownTime; //The time it takes to reuse the healing
    public GameObject healPrefab;
    public Image placeholderBG;
    public Image placeholderFill;
    public Color traslucidWhite;
    public Color lightGreen;

    private bool isHealActive = false;
    private float fillTimer;

    void Start()
    {
        SetupPlaceholder(); //Initialize varibles to default sta
    }

    void Update()
    {
        //Filling the image placeholder base in the time
        if (fillTimer <= cooldownTime)
        {
            fillTimer += Time.deltaTime;
            placeholderFill.fillAmount = (1.0f / cooldownTime) * fillTimer;
        }
        else if(!isHealActive)
        {
            //Here, the heal is ready to use it
            isHealActive = true;
            placeholderFill.color = lightGreen; //Change placeholder color to green (active)
            InstantiateHeal();
        }

        ///Debug
        if (Input.GetKeyDown(KeyCode.I))
            InstantiateHeal();
    }

    public void ResetPosition(Transform _target)
    {
        _target.position = transform.position;
    }

    public void SetupPlaceholder()
    {
        //Setup the placeholder variables to the default start values
        isHealActive = false;
        fillTimer = 0.0f;
        placeholderFill.fillAmount = 0.0f;
        placeholderFill.color = traslucidWhite; //Change placeholder color white
    }

    private void InstantiateHeal()
    {
        GameObject go = Instantiate(healPrefab, transform); //Create heal
        go.GetComponent<HealCaster>().placeholder = this; //Let know the heal object that this is the placeholder
    }

}
