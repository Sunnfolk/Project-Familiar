using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_PlayerHealth = 3;
    public float m_PlayerScore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            //Insert die script here
            m_PlayerHealth--;
        }

        void Update()
        {
            /*if (m_PlayerHealth == 3f)
            {
                print("dead");
            }
            if (m_PlayerHealth == 2f)
            {
                print("dead");
            }
            if (m_PlayerHealth == 1f)
            {
                print("dead");
            }
            if (m_PlayerHealth == 0f)
            {
                print("dead");
            }*/
        }
    }
}
