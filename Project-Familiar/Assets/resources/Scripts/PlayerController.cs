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
            print("dead");
        }

        void Update()
        {
            if (m_PlayerHealth == 0f)
            {
                print("dead");
            }
        }
    }
}
