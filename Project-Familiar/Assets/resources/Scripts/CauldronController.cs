using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CauldronController : MonoBehaviour
{
    private AngerMeter m_AngerMeter; 
    public GameObject m_Projectile;
    [HideInInspector] public Vector3 m_Position;
    private float m_ShootCounter;
    [SerializeField] private float shootFq =5f;
    public float angerIncreaseFq = 2f;
    [SerializeField] private float m_Anger;
    [HideInInspector]public bool stage2;
    [HideInInspector] public bool stage3;
    [HideInInspector] public bool stage1;
    [SerializeField] private float minShootFq = 0.1f;
    [SerializeField] private float stage1ShootFq = 1f;
    [SerializeField] private float stage2ShootFq = 2f;
    [SerializeField] private float stage3ShootFq = 3f;
    private AudioSource m_Audio;
    public AudioClip Shoot;


    void Start()
    {
        m_AngerMeter = GameObject.Find("AngerMeter").GetComponent<AngerMeter>();
        m_ShootCounter = shootFq;
        m_Anger = angerIncreaseFq;
        m_Position = transform.position;
        m_Audio = GetComponent<AudioSource>();
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
            m_Audio.PlayOneShot(Shoot);
        }
        if (shootFq <= 0)
        {
            shootFq = minShootFq;
        }
        AngerMeter();
       
    }
    private void ShootProjectile ()
    {
        Instantiate(m_Projectile,m_Position, new Quaternion());
    }

    private void AngerMeter()
    {
        if (m_AngerMeter.angerStop) return;
        if (m_Anger > 0)
        {
            m_Anger -= Time.deltaTime;
        }

        if (m_Anger <= 0)
        {
            m_Anger = angerIncreaseFq;
            m_AngerMeter.meter++;
        }

        if (m_AngerMeter.meter < 10 && !stage1)
        {
            shootFq = stage1ShootFq;
            stage1 = true;
        }
        else 
        {
            stage1 = false;
        }

        if (m_AngerMeter.meter>=10 && !stage2)
        {
            shootFq = stage2ShootFq;
            stage2 = true;
        }
        else
        {
            stage2 = false;
        }
        if (m_AngerMeter.meter>=19 && !stage3)
        {
            shootFq = stage3ShootFq;
            stage3 = true;
        }
        else
        {
            stage3 = false;
        }
    }
}
