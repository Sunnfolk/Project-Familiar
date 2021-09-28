using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_PlayerHealth = 3;
    private PlayerMove m_PlayerMove;

    private void Start()
    {
        m_PlayerMove = GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            if (!m_PlayerMove.m_Dashing)
            {
                //TODO Insert die script here
                m_PlayerHealth--;
            }
        }
    }
}
