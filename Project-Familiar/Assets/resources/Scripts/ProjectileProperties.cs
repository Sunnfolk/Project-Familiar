using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileProperties : MonoBehaviour
{
    [SerializeField] private float m_Speed= 1f;
    [SerializeField] private float m_Angle;
    void Start()
    {
        transform.Rotate(0, 0, m_Angle);
    }

  
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            transform.Rotate(0, 0, Random.Range(0f, 360f));
        }
        transform.Translate(Vector2.up * m_Speed * Time.deltaTime);
    }
}
