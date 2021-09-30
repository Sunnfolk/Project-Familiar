using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ItemRequest m_Request;
    public float playerHealth = 3;
    private float m_PlayerScore;
    public float highScore;
    private SceneControl m_SceneControl;
    private void Start()
    {
        m_Request = GameObject.Find("Cauldron").GetComponent<ItemRequest>();
        m_SceneControl = GetComponent<SceneControl>();
    }

    private void Update()
    {
        if (m_Request.m_Success)
        {
            m_PlayerScore++;
            print(m_PlayerScore);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            playerHealth--;
        }
    }

    public void Die()
    {
        highScore = m_PlayerScore;
        m_PlayerScore = 0f;
        m_SceneControl.LoadScene("Win Menu");
    }
}
