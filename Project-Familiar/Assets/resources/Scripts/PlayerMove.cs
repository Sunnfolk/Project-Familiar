
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
    private bool applePicked;

    public GameObject currentPickup;

    private void Start()
    {
        m_Input = GetComponent<PlayerInput>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        applePicked = false;
    }

    private void Update()
    {
        if (canPick && m_Input.interact)
        {
            if (currentPickup.CompareTag("Apple"))
            {
                // set apple
            }

            if (currentPickup.CompareTag("Potion"))
            {
                
            }
            
            if (currentPickup.CompareTag("Book"))
            {
                
            }
            
            if (currentPickup.CompareTag("Tentacle"))
            {
                
            }


            Destroy(currentPickup);
            canPick = false;
            canDrop = true;
        }
        
        
        
    }

    private void FixedUpdate()
    {
        m_Rigidbody2D.velocity = new Vector2(m_Input.moveVector.x * moveSpeed, m_Input.moveVector.y * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
     { 
         ItemCollision(other);
     }

    private void OnTriggerExit2D(Collider2D other)
    {
        canPick = false;
        currentPickup = null;
    }

    private void ItemCollision(Collider2D other)
     {
         if (other.CompareTag("Apple"))
         {
             currentPickup = other.gameObject;
             canPick = true;
         }

         if (other.CompareTag("Potion"))
         {
             currentPickup = other.gameObject;
             canPick = true;
         }
         
         if (other.CompareTag("Book"))
         {
             currentPickup = other.gameObject;
             canPick = true;
         }
         
         if (other.CompareTag("Tentacle"))
         {
             currentPickup = other.gameObject;
             canPick = true;
         }

     }
}
