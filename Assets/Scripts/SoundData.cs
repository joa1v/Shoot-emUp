using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundData
{
    public AudioClip[] audioClips = new AudioClip[0];
    [Range(0,1)]
    public float volume = .5f;
}

