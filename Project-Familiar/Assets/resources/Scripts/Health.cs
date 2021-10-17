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
            IsDead = true;
        }
        
    }
}
