
using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    [HideInInspector]public bool m_Dashing;
    private PlayerInput m_Input;
    private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private float dashSpeed = 3f;
    [SerializeField] private float dashTimer = 1f;
    [SerializeField] private float m_DashTimerCounter;
    //[SerializeField] private float maxVelocity = -20f;
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
        m_DashTimerCounter = dashTimer;
    }

    private void Update()
    {
        if (m_DashTimerCounter > 0 && m_Dashing)
        {
            m_DashTimerCounter -= Time.deltaTime;
        }

        if (m_DashTimerCounter <= 0)
        {
            m_DashTimerCounter = dashTimer;
            m_Dashing = false;
        }
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
        if (m_Input.dash)
        {
            Dash();
        }

    }

    private void FixedUpdate()
    {
        if (!m_Dashing)
        {
            m_Rigidbody2D.velocity = new Vector2(m_Input.moveVector.x * moveSpeed, m_Input.moveVector.y * moveSpeed);
        }
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

    private void Dash()
    {
        m_Dashing = true;
        print(m_Input.KeyLastP);
        if (m_Input.KeyLastP == 0)
        {
            m_Rigidbody2D.AddForce(Vector2.up * dashSpeed, ForceMode2D.Impulse);
        }
        if (m_Input.KeyLastP == 1)
        {
            m_Rigidbody2D.AddForce(Vector2.down * dashSpeed, ForceMode2D.Impulse);
        }
        if (m_Input.KeyLastP == 2)
        {
            m_Rigidbody2D.AddForce(Vector2.left * dashSpeed, ForceMode2D.Impulse);
        }
        if (m_Input.KeyLastP == 3)
        {
            m_Rigidbody2D.AddForce(Vector2.right * dashSpeed, ForceMode2D.Impulse);
        }
    }
}
