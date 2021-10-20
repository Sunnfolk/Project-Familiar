using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSounds : MonoBehaviour
{
    public AudioClip Fireball;
    private AudioSource m_Audio;

    // Start is called before the first frame update
    void Start()
    {
        m_Audio = GetComponent<AudioSource>();
        m_Audio.PlayOneShot(Fireball);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
