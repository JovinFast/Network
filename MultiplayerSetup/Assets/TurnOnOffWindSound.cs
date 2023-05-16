using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffWindSound : MonoBehaviour
{
    AudioSource aS;
    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }


   public void TurnUpWind()
    {
        aS.volume = 1;
    }
    public void TurnDownWind()
    {
        aS.volume = 0.5f;
    }
}
