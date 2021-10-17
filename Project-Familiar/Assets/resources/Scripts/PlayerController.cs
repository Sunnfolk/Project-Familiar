
using System.Collections;
using TMPro;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private ItemRequest m_Request;
    public float playerHealth = 3f;
    private float m_PlayerScore;
    public static float highScore;
    private SceneControl m_SceneControl;
    public TMP_Text scoreDisplay;
    private AudioSource m_AudioSource;
    public AudioClip Hurt;
    public PlayerAnimation m_Animation;
    
    [HideInInspector] public bool isTakingDamage;
    [SerializeField] private float damageDuration = 0.3f;
    private void Start()
    {
        m_Request = GameObject.Find("Cauldron").GetComponent<ItemRequest>();
        m_SceneControl = GetComponent<SceneControl>();
        m_AudioSource = GetComponent<AudioSource>();
        m_Animation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        if (m_Request.getScore)
        {
            m_PlayerScore++;
            scoreDisplay.text = "Score: "+m_PlayerScore;
            m_Request.getScore = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            playerHealth--;
            StartCoroutine(isTakingDamager(damageDuration));
            m_AudioSource.PlayOneShot(Hurt);
        }
    }

    public void HasDied()
    {
        highScore = m_PlayerScore;
        m_PlayerScore = 0f;
        m_SceneControl.LoadScene("Win Menu");
    }

    private IEnumerator isTakingDamager(float damageDuration)
    {
        isTakingDamage = true;
        yield return new WaitForSeconds(damageDuration);
        isTakingDamage = false;
    }
}
