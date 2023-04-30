using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UISound : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void onHover()
    {
        audio.PlayOneShot(hoverSound);
    }

    public void onClick()
    {
        audio.PlayOneShot(clickSound);
    }
}
