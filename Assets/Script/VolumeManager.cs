using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer _audio;

    public void Setvolume(float vol)
    {
        _audio.SetFloat("vol", vol);
    }
}
