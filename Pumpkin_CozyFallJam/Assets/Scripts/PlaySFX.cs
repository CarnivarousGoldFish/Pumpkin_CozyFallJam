using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{

    public AudioSource sfx;

    public void Play()
    {
        if (sfx.isPlaying)
            return;

        sfx.Play();
    }
}
