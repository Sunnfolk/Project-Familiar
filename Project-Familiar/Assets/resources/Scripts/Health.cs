using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private PlayerController m_PlayerController;
    //public GameObject m_Player;
    private SpriteRenderer SpriteRenderer;
    public Sprite FullHeatlhSprite;
    public Sprite TwoHeatlhSprite;
    public Sprite OneHeatlhSprite;
    void Start()
    {
        m_PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (m_PlayerController.m_PlayerHealth == 3f)
        {
            SpriteRenderer.sprite = FullHeatlhSprite;
        }
        else if (m_PlayerController.m_PlayerHealth == 2f)
        {
            SpriteRenderer.sprite = TwoHeatlhSprite;
        }
        else if (m_PlayerController.m_PlayerHealth == 1f)
        {
            SpriteRenderer.sprite = OneHeatlhSprite;
        }
        else
        {
            print("dead");
        }
        
    }
}
