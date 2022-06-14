using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private float disappearTimer = 1.75f;
    private float disappearSpeed = 3.0f;
    private TextMeshPro textUI;
    private Color tempColor;

    void Awake()
    {
        textUI = GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        tempColor = textUI.color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        disappearTimer -= Time.deltaTime;

        if(disappearTimer < 0f)
        {
            //Start disappearing
            tempColor.a -= disappearSpeed * Time.deltaTime;
            textUI.color = tempColor;
            if (tempColor.a <= 0)
                Destroy(gameObject);
        }
    }

}
