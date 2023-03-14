using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public void PlayAudio(AudioClip audio)
    {
        this.GetComponent<AudioSource>().clip = audio;
        this.GetComponent<AudioSource>().Play();
    }
}
