using UnityEngine;

public class ProjectileProperties : MonoBehaviour
{
    [SerializeField] private float m_Speed= 1f;
    void Start()
    {
        
    }

  
    void Update()
    {
        transform.Translate(Vector2.up * m_Speed * Time.deltaTime);
    }
}
