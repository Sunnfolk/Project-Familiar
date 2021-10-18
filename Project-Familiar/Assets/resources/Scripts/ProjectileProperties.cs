using UnityEngine;
using UnityEngine.Serialization;

public class ProjectileProperties : MonoBehaviour
{
    [SerializeField] private float speed= 1f;
    [SerializeField] private float lifetime = 1f;
    private Health m_Health;

    void Start()
    {
        m_Health = GameObject.Find("Health").GetComponent<Health>();
        Destroy(gameObject,lifetime);
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
        if (m_Health.IsDead) return;
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}