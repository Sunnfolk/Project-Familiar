using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    private PlayerController m_PlayerController;

    public PlayerAnimation m_PlayerAnim;
    //public GameObject m_Player;
    private SpriteRenderer SpriteRenderer;
    public Sprite FullHeatlhSprite;
    public Sprite TwoHeatlhSprite;
    public Sprite OneHeatlhSprite;
    [HideInInspector] public bool IsDead;
    public UnityEngine.Rendering.Universal.Light2D GlobalLight;
    public float fadeTime = 0.1f;
    private bool m_Switch1;
    void Start()
    {
        m_PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (m_PlayerController.playerHealth == 3f)
        {
            SpriteRenderer.sprite = FullHeatlhSprite;
            IsDead = false;
        }
        else if (m_PlayerController.playerHealth == 2f)
        {
            SpriteRenderer.sprite = TwoHeatlhSprite;
            IsDead = false;
        }
        else if (m_PlayerController.playerHealth == 1f)
        {
            SpriteRenderer.sprite = OneHeatlhSprite;
            IsDead = false;
        }
        else
        {
            if (!m_Switch1)
            {
                StartCoroutine(nameof(Timer));
                m_Switch1 = true;
            }
            IsDead = true;
        }
    }

    private IEnumerator Timer()
    {
        for (float i = 8; i > 0; i--)
        {
            GlobalLight.intensity = i/10;
            yield return new WaitForSeconds(fadeTime);
        }
    }
}
