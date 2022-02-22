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
    public void CorrectItemSound()
    {
        var random = Random.Range(0, CorrectItem.Length);
        Audio.PlayOneShot(CorrectItem[random]);
    }

    public void WrongItemSound()
    {
        var random = Random.Range(0, WrongItem.Length);
        Audio.PlayOneShot(WrongItem[random]);
    }

    public void GameOverSound()
    {
        var random = Random.Range(0, GameOver.Length);
        Audio.PlayOneShot(GameOver[random]);
    }

    public void AngerSound()
    {
        if (m_Cauldron.stage1)
        {
            var random = Random.Range(0,Anger1.Length);
            Audio.PlayOneShot(Anger1[random]);
        }

        if (m_Cauldron.stage2)
        {
            var random = Random.Range(0,Anger2.Length);
            Audio.PlayOneShot(Anger2[random]);
        }

        if (m_Cauldron.stage3)
        {
            var random = Random.Range(0,Anger3.Length);
            Audio.PlayOneShot(Anger3[random]);
        }
    }
}
