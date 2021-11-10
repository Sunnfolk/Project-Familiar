using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
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
    public Health health;
    public ProjectileForeshadowing foreshadowing;
    [SerializeField] private float foreshadowDelay = 0.2f;
    [SerializeField] private float lightDelay = 0.2f;
    public Light2D spotlight;
    public Light2D shootlight;
    [SerializeField] private float cauldronLightFade = 0.01f;
    [SerializeField] private float shootLightFade = 0.05f;
    [SerializeField] private int cauldronLightMaxIntensity = 7;
    [SerializeField] private int shootLightMaxIntensity = 4;
    public GameObject WarnLight;


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
        if (health.IsDead) return;
        if (m_ShootCounter > 0)
        {
            m_ShootCounter -= Time.deltaTime;
        }
        if (m_ShootCounter <= 0)
        {
            m_ShootCounter = m_ShootFq;
            ShootProjectile();
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
        foreshadowing.Foreshadow(angle);
        //foreshadowLight.SetActive(true);
        StartCoroutine(nameof(Timer));
    }

    private IEnumerator Timer()
    {
        for (float i = 0; i <= shootLightMaxIntensity; i++)
        {
            shootlight.intensity = i/10;
            yield return new WaitForSeconds(shootLightFade);
        } 
        yield return new WaitForSeconds(foreshadowDelay);
        Instantiate(m_Projectile,m_Position, Quaternion.Euler(0,0,angle));
        m_Audio.PlayOneShot(Shoot);
        //shootSpotlight.SetActive(true);
        for (float i = 0; i <= cauldronLightMaxIntensity; i++)
        {
            spotlight.intensity = i/10;
            yield return new WaitForSeconds(cauldronLightFade);
        }
        yield return new WaitForSeconds(lightDelay);
        for (float i = cauldronLightMaxIntensity; i >= 0; i--)
        {
            spotlight.intensity = i/10;
            yield return new WaitForSeconds(cauldronLightFade);
        }
        for (float i = shootLightMaxIntensity; i >= 0; i--)
        {
            shootlight.intensity = i/10;
            yield return new WaitForSeconds(shootLightFade);
        }
        //StartCoroutine(nameof(Timer2));
    }

    /*private IEnumerator Timer2()
    {
        
    }*/

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
            WarnLight.SetActive(false);
        }
        else
        {
            WarnLight.SetActive(true);
            stage3 = false;
        }
    }
}
