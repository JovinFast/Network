using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayUICanvas : MonoBehaviour
{
    [SerializeField] GameObject HPDisplay;
   public void DisplayHP()
    {
        HPDisplay.SetActive(true);
    }
}
