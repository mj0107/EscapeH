using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshSoundStop : MonoBehaviour
{
    public void SoundOn()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }


    public void SoundStop()
    {
        gameObject.GetComponent<AudioSource>().Stop();
    }
}
