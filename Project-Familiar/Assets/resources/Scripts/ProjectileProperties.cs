using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileProperties : MonoBehaviour
{
    [SerializeField] private float m_Speed= 1f;
    public float m_MinAngleRange;
    public float m_MaxAngleRange;
    [SerializeField] private float m_Lifetime = 1f;
    //private CauldronController m_CauldronController;
    void Start()
    {
        //m_CauldronController = GameObject.Find("Cauldron").GetComponent<CauldronController>();
        //print(m_CauldronController.m_Position);
        transform.Rotate(0, 0, Random.Range(m_MinAngleRange, m_MaxAngleRange));
        Destroy(gameObject,m_Lifetime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
  
    void Update()
    {
        transform.Translate(Vector2.up * m_Speed * Time.deltaTime);
    }
}