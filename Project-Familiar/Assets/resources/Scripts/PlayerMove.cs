using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float puddleSpeed = 3f;
    public bool m_Puddle;
    [HideInInspector]public bool m_Dashing;
    private bool m_CanDash = true;
    private bool m_StartTimer;
    private PlayerInput m_Input;
    private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private float dashSpeed = 3f;
    [SerializeField] private float dashTimer = 1.2f; 
    private float m_DashTimerCounter;
    [SerializeField] private float dashDuration= 1;
    private Animator m_Animator;
    private AudioSource m_Audio;
    public AudioClip dash;
    private GameObject Puddle;

    private void Start()
    {
        m_Input = GetComponent<PlayerInput>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_DashTimerCounter = dashTimer;
        m_Audio = GetComponent<AudioSource>();
        m_Puddle = false;
    }

    private void Update()
    {
        if (m_DashTimerCounter > 0 && m_StartTimer)
        {
            m_DashTimerCounter -= Time.deltaTime;
        }

        if (m_DashTimerCounter <= dashDuration)
        {
            m_CanDash=false;
            m_Dashing = false;
        }

        if (m_DashTimerCounter <= 0)
        {
            m_StartTimer = false;
            m_DashTimerCounter = dashTimer;
            m_CanDash= true;
            m_StartTimer = false;
        }

        if (m_Input.dash && m_CanDash)
        {
            Dash();
            m_Audio.PlayOneShot(dash);
        }

    }

    private void FixedUpdate()
    {
        
        if (m_Puddle && !m_Dashing)
        {
            m_Rigidbody2D.velocity =
                Vector2.ClampMagnitude(
                    new Vector2(m_Input.moveVector.x * puddleSpeed, m_Input.moveVector.y * puddleSpeed), puddleSpeed);
        }
        else if (!m_Dashing)
        {
            m_Rigidbody2D.velocity =
                Vector2.ClampMagnitude(new Vector2(m_Input.moveVector.x * moveSpeed, m_Input.moveVector.y * moveSpeed), moveSpeed);
        }
        
    }

    private void Dash()
    {
        m_StartTimer = true;
        m_Dashing = true;
        m_StartTimer = true;
        if (m_Input.KeyLastP == 0)
        {
            m_Rigidbody2D.AddForce(Vector2.up * dashSpeed, ForceMode2D.Impulse);
            //m_Animator.Play("Dash");
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
        m_CanDash = false;
    }

    private void OnTriggerEnter2D(Collider2D Puddle)
    {
        if (Puddle.gameObject.CompareTag("puddle"))
        {
            m_Puddle = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D Puddle)
    {
        if (Puddle.gameObject.CompareTag("puddle"))
        {
            m_Puddle = false;
        }

    }
}