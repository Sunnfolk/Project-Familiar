using UnityEngine;
using UnityEngine.InputSystem;

public class CauldronController : MonoBehaviour
{
    public GameObject m_Projectile;
    [HideInInspector] public Vector3 m_Position;
    private float m_ShootCounter;
    [SerializeField] private float m_ShootFq =5f;
    [SerializeField] private float m_MaxAnger = 20f;
    private float m_Anger;
    [HideInInspector]public bool m_Switch1;
    [HideInInspector] public bool m_Switch2;
    void Start()
    {
        m_ShootCounter = m_ShootFq;
        m_Anger = m_MaxAnger;
        m_Position = transform.position;
    }
    void Update()
    {
        if (m_Anger > 0)
        {
            m_Anger -= Time.deltaTime;
        }
        
        if (m_ShootCounter > 0)
        {
            m_ShootCounter -= Time.deltaTime;
        }
        if (m_ShootCounter <= 0)
        {
            m_ShootCounter = m_ShootFq;
            if (m_Switch1)
            {
                ShootProjectile();
            }
        }
        
        if (m_Anger <= 10 && !m_Switch1)
        {
            m_ShootFq -= 0.5f;
            print("Angrier");
            m_Switch1 = true;
        }
        
        if (m_Anger <= 0 && !m_Switch2)
        {
            m_ShootFq -= 2f;
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
