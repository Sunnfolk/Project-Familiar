
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


public class PlayerController : MonoBehaviour
{
    private ItemRequest m_Request;
    public float playerHealth = 3f;
    public static float PlayerScore;
    public static float HighScore;
    private SceneControl m_SceneControl;
    public TMP_Text scoreDisplay;
    private AudioSource m_AudioSource;
    public AudioClip Hurt;
    public PlayerAnimation m_Animation;
    public CauldronController cauldron;
    public float angerFqDecrease =0.05f;
    
    [HideInInspector] public bool isTakingDamage;
    [SerializeField] private float damageDuration = 0.3f;
    private void Start()
    {
        PlayerScore = 0f;
        m_Request = GameObject.Find("Cauldron").GetComponent<ItemRequest>();
        m_SceneControl = GetComponent<SceneControl>();
        m_AudioSource = GetComponent<AudioSource>();
        m_Animation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        if (m_Request.getScore)
        {
            cauldron.angerIncreaseFq -= angerFqDecrease;
            PlayerScore++;
            scoreDisplay.text = "Score: "+PlayerScore;
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
        if (PlayerScore > HighScore)
        {
            HighScore = PlayerScore;
        }
        m_SceneControl.LoadScene("Win Menu");
    }

    private IEnumerator isTakingDamager(float damageDuration)
    {
        isTakingDamage = true;
        yield return new WaitForSeconds(damageDuration);
        isTakingDamage = false;
    }
}
