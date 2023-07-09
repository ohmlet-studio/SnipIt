using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip pickup, dropdown, snip, unlock;

    public void grabS()
    {
        src.clip = pickup;
        src.Play();
    }

    public void dropS()
    {
        src.clip = dropdown;
        src.Play();
    }

    public void snipS()
    {
        src.clip = snip;
        src.Play();
    }

    public void unlockS()
    {
        src.clip = unlock;
        src.Play();
    }
}
