using UnityEngine;
using UnityEngine.Serialization;

public class ProjectileProperties : MonoBehaviour
{
    [SerializeField] private float speed= 1f;
    [SerializeField] private float lifetime = 1f;

    void Start()
    {
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
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}