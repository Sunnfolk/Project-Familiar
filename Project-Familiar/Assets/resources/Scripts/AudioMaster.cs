using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMaster : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    public void SetSFXVol(float sfxvol)
    {
        _audioMixer.SetFloat("SFXVolume", sfxvol);
    }

    public void SetMusicVol(float musicvol)
    {
        _audioMixer.SetFloat("MusicVolume", musicvol);
    }

    public void ClearVolume(string name)
    {
        _audioMixer.ClearFloat(name);
    }
}
