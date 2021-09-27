using UnityEngine;
using UnityEngine.InputSystem;

public class CauldronController : MonoBehaviour
{
    [SerializeField]private float m_AngerDecreaseFq = 1;
    [SerializeField]private float m_AngerCounter;
    private float m_Anger;
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
            m_AngerCounter--;
            ShootProjectile();
            print("timesup");
        }

        if (m_AngerCounter <= m_AngerDecreaseFq)
        {
            m_Anger--;
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
