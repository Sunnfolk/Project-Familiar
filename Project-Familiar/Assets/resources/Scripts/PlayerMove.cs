
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    private PlayerInput m_Input;
    private Rigidbody2D m_Rigidbody2D;

    private void Start()
    {
        m_Input = GetComponent<PlayerInput>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        m_Rigidbody2D.velocity = new Vector2(m_Input.moveVector.x * moveSpeed, m_Input.moveVector.y * moveSpeed);
    }
}
