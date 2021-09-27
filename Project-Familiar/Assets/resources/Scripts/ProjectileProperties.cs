using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileProperties : MonoBehaviour
{
    [SerializeField] private float m_Speed= 1f;
    [SerializeField] private float m_Angle;
    public float m_MinAngleRange;
    public float m_MaxAngleRange;
    void Start()
    {
        transform.Rotate(0, 0, m_Angle);
    }

  
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            transform.Rotate(0, 0, Random.Range(m_MinAngleRange, m_MaxAngleRange));
        }
        transform.Translate(Vector2.up * m_Speed * Time.deltaTime);
    }
}
