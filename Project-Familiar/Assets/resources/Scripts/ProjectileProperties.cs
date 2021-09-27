using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileProperties : MonoBehaviour
{
    [SerializeField] private float m_Speed= 1f;
    [SerializeField] private float m_Angle;
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

  
    void Update()
    {
        
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            //transform.Rotate(0, 0, Random.Range(m_MinAngleRange, m_MaxAngleRange));
            //transform.position = m_CauldronController.m_Position;
            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * m_Speed * Time.deltaTime);
    }
}