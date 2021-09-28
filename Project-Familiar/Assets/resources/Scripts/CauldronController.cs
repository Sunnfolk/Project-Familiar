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
    [SerializeField] private float maxAnger = 20f;
    [SerializeField]private float m_Anger;
    [HideInInspector]public bool m_Switch1;
    [HideInInspector] public bool m_Switch2;
    
    
    void Start()
    {
        m_AngerMeter = GameObject.Find("AngerMeter").GetComponent<AngerMeter>();
        m_ShootCounter = shootFq;
        m_Anger = maxAnger;
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
        if (m_Anger > 0)
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
            m_Anger = maxAnger;
            shootFq -= 0.5f;
            m_AngerMeter.meter++;
            print("Im super angry");
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
