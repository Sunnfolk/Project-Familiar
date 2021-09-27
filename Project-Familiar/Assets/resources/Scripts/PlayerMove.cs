
using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    private PlayerInput m_Input;
    private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private float dashSpeed = 3f;
    [SerializeField] private float maxVelocity = -20f;
    private bool canDash;
    private bool canPick;
    private bool canDrop = false;
    private bool applePicked;

    [FormerlySerializedAs("currentPickup")] public GameObject lookingAtPickup;
    public GameObject currentPickup;

    private void Start()
    {
        m_Input = GetComponent<PlayerInput>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        applePicked = false;
        currentPickup = null;
    }

    private void Update()
    {
        
        if (canDrop && m_Input.interact)
        {
            Instantiate(currentPickup, transform.position, quaternion.identity);
            currentPickup = null;
        }
        
        if (canPick && m_Input.interact)
        {
            
            currentPickup = lookingAtPickup;
            if (lookingAtPickup.CompareTag("Apple"))
            {
                // set apple
            }

            if (lookingAtPickup.CompareTag("Potion"))
            {
                
            }
            
            if (lookingAtPickup.CompareTag("Book"))
            {
                
            }
            
            if (lookingAtPickup.CompareTag("Tentacle"))
            {
                
            }


            //Destroy(lookingAtPickup);
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
        lookingAtPickup = null;
    }

    private void ItemCollision(Collider2D other)
     {
         if (other.CompareTag("Apple"))
         {
             lookingAtPickup = other.gameObject;
             canPick = true;
         }

         if (other.CompareTag("Potion"))
         {
             lookingAtPickup = other.gameObject;
             canPick = true;
         }
         
         if (other.CompareTag("Book"))
         {
             lookingAtPickup = other.gameObject;
             canPick = true;
         }
         
         if (other.CompareTag("Tentacle"))
         {
             lookingAtPickup = other.gameObject;
             canPick = true;
         }

     }
}
