using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CauldronController : MonoBehaviour
{
    private AngerMeter m_AngerMeter; 
    public GameObject m_Projectile;
    [HideInInspector] public Vector3 m_Position;
    private float m_ShootCounter;
    private float m_ShootFq =5f;
    public float angerIncreaseFq = 2f;
    [SerializeField] private float m_Anger;
    [HideInInspector]public bool stage2;
    [HideInInspector] public bool stage3;
    [HideInInspector] public bool stage1;
    [SerializeField] private float minShootFq = 0.1f;
    [SerializeField] private float stage1ShootFq = 1f;
    [SerializeField] private float stage2ShootFq = 2f;
    [SerializeField] private float stage3ShootFq = 3f;
    public float minAngleRange;
    public float maxAngleRange;
    public float angle;
    private AudioSource m_Audio;
    public AudioClip Shoot;
    public ProjectileForeshadowing Foreshadowing;
    [SerializeField] private float foreshadowDelay = 0.2f;
    public Health Health;


    void Start()
    {
        m_AngerMeter = GameObject.Find("AngerMeter").GetComponent<AngerMeter>();
        m_ShootCounter = m_ShootFq;
        m_Anger = angerIncreaseFq;
        m_Position = transform.position;
        m_Audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Health.IsDead) return;
        if (m_ShootCounter > 0)
        {
            m_ShootCounter -= Time.deltaTime;
        }
        if (m_ShootCounter <= 0)
        {
            m_ShootCounter = m_ShootFq;
            ShootProjectile();
            m_Audio.PlayOneShot(Shoot);
        }
        if (m_ShootFq <= 0)
        {
            m_ShootFq = minShootFq;
        }
        AngerMeter();
       
    }
    private void ShootProjectile ()
    {
        angle = Random.Range(minAngleRange, maxAngleRange);
        Foreshadowing.Foreshadow(angle);
        StartCoroutine(nameof(Timer));
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(foreshadowDelay);
        Instantiate(m_Projectile,m_Position, Quaternion.Euler(0,0,angle));
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
            m_ShootFq = stage1ShootFq;
            stage1 = true;
        }
        else 
        {
            stage1 = false;
        }

        if (m_AngerMeter.meter>=10 && !stage2)
        {
            m_ShootFq = stage2ShootFq;
            stage2 = true;
        }
        else
        {
            stage2 = false;
        }
        if (m_AngerMeter.meter>=19 && !stage3)
        {
            m_ShootFq = stage3ShootFq;
            stage3 = true;
        }
        else
        {
            stage3 = false;
        }
    }
}
