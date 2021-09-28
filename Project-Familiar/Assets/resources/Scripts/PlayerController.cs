using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_PlayerHealth = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            m_PlayerHealth--;
        }
    }
}
