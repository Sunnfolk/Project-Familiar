using UnityEngine;
using UnityEngine.InputSystem;

public class CauldronController : MonoBehaviour
{
    public GameObject m_Projectile;
    public Vector3 m_Position;
    [SerializeField] private float m_TimerCounter;
    [SerializeField] private float m_Timer =5f;
    void Start()
    {
        m_TimerCounter = m_Timer;
        m_Position = transform.position;
    }

    void Update()
    {
        if (m_TimerCounter > 0)
        {
            m_TimerCounter -= Time.deltaTime;
        }

        if (m_TimerCounter <= 0)
        {
            m_TimerCounter = m_Timer;
            shootProjectile();
            print("timesup");
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            shootProjectile();
        }
    }
    private void shootProjectile ()
    {
        Instantiate(m_Projectile,m_Position, new Quaternion());
    }
}
