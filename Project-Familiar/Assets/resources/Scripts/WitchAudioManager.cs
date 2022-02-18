using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WitchAudioManager : MonoBehaviour
{

    private CauldronController m_Cauldron;
    private AudioSource Audio;
    private AudioClip[] Anger1;
    private AudioClip[] Anger2;
    private AudioClip[] Anger3;
    private AudioClip[] GameOver;
    private AudioClip[] WrongItem;
    private AudioClip[] CorrectItem;
    

    private void Start()
    {
        m_Cauldron = GetComponent<CauldronController>();
        Audio = GetComponent<AudioSource>();
    }

    private void AngerSound()
    {
        if (m_Cauldron.stage1)
        {
            
        }

        if (m_Cauldron.stage2)
        {
            
        }

        if (m_Cauldron.stage3)
        {
            
        }
    }
}
