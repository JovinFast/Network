using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Alteruna;

public class DisplayHealth : MonoBehaviour
{
    TextMeshProUGUI healthText;
    Health healthScript;

    private Alteruna.Avatar avatar;

    private void Awake()
    {
        avatar = GetComponent<Alteruna.Avatar>();
        
    }
    private void Start()
    {
        if (!avatar.IsMe)
        {
            enabled = false;
        }
        healthText = GameObject.FindGameObjectWithTag("HPDisplay").GetComponentInChildren<TextMeshProUGUI>();
        healthScript = GetComponent<Health>();
        UpdateHealth();

    }

    public void UpdateHealth()
    {
        healthText.text = "Health: " + healthScript.currentHealth.ToString();
    }
}
