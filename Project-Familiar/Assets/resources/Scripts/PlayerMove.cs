
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    private PlayerInput m_Input;
    private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private float dashSpeed = 3f;
    [SerializeField] private float maxVelocity = -20f;
    private bool canDash;
    private bool canPick;
    private bool canDrop;

    private void Start()
    {
        m_Input = GetComponent<PlayerInput>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        m_Rigidbody2D.velocity = new Vector2(m_Input.moveVector.x * moveSpeed, m_Input.moveVector.y * moveSpeed);
    }

        private void OnTriggerEnter2D(Collider2D other)
     { 
         ItemCollision(other);
     }

     private void ItemCollision(Collider2D other)
     {
         if (!other.CompareTag("Item")) return;
         Destroy(other.gameObject);
    }
}
