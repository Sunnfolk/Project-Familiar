using UnityEngine;
using UnityEngine.InputSystem;

public class CauldronController : MonoBehaviour
{
    private float m_AngerCounter;
    public GameObject m_Projectile;
    public Vector3 m_Position;
    private float m_ShootCounter;
    [SerializeField] private float m_ShootFq =5f;
    [SerializeField] private float m_AngerTimer = 2f;
    [SerializeField] private float m_Anger = 2f;
    private bool m_Switch1;
    private bool m_Switch2;
    void Start()
    {
        m_ShootCounter = m_ShootFq;
        m_AngerCounter = m_AngerTimer;
        m_Position = transform.position;
    }
    void Update()
    {
        if (m_AngerCounter > 0)
        {
            m_AngerCounter -= Time.deltaTime;
        }

        if (m_AngerCounter <= 0)
        {
            m_AngerCounter = m_AngerTimer;
            m_Anger--;
            //print(m_Anger);
        }
        if (m_ShootCounter > 0)
        {
            m_ShootCounter -= Time.deltaTime;
        }
        if (m_ShootCounter <= 0)
        {
            m_ShootCounter = m_ShootFq;
            ShootProjectile();
        }

        if (m_Anger <= 10 && !m_Switch1)
        {
            m_ShootFq -= 0.5f;
            m_Switch1 = true;
        }
        
        if (m_Anger <= 0 && !m_Switch2)
        {
            print("Im super angry");
            m_Switch2 = true;
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            ShootProjectile();
        }
    }
    private void ShootProjectile ()
    {
        Instantiate(m_Projectile,m_Position, new Quaternion());
    }
}
