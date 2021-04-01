using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
This class creates the sounds effects seen when users hover over the buttons
in the main menu.
**/
public class btnFX : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;


    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);

    }

    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }
}
