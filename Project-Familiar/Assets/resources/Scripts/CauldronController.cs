using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CauldronController : MonoBehaviour
{
    private AngerMeter m_AngerMeter;
    public GameObject m_Projectile;
    public Vector3 m_Position;
    private float m_ShootCounter;
    [SerializeField] private float shootFq =5f;
    [SerializeField] private float angerIncreaseFq = 2f;
    private float m_Anger;
    [HideInInspector]public bool m_Switch1;
    [HideInInspector] public bool m_Switch2;
    [SerializeField] private float minShootFq = 0.1f;
    
    
    void Start()
    {
        m_AngerMeter = GameObject.Find("AngerMeter").GetComponent<AngerMeter>();
        m_ShootCounter = shootFq;
        m_Anger = angerIncreaseFq;
        m_Position = transform.position;
    }
    void Update()
    {
        if (m_ShootCounter > 0)
        {
            m_ShootCounter -= Time.deltaTime;
        }
        if (m_ShootCounter <= 0)
        {
            m_ShootCounter = shootFq;
            ShootProjectile();
        }
        if (shootFq <= 0)
        {
            shootFq = minShootFq;
        }
        if (m_Anger > 0 && !m_AngerMeter.AngerStop)
        {
            m_Anger -= Time.deltaTime;
        }
        /*if (m_Anger <= 10 && !m_Switch1)
        {
            m_ShootFq -= 0.5f;
            print("Angrier");
            m_Switch1 = true;
        }*/
        
        if (m_Anger <= 0)
        {
            m_Anger = angerIncreaseFq;
            m_AngerMeter.meter++;
            print("Im super angry");
        }

        if (m_AngerMeter.meter==10 && !m_Switch1)
        {
            if(shootFq > 0)
            {
                shootFq -= 0.5f;
            }
            
            m_Switch1 = true;
        }
        if (m_AngerMeter.meter==19 && !m_Switch2)
        {
            if(shootFq > 0)
            {
                shootFq -= 0.5f;
            }
            
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
