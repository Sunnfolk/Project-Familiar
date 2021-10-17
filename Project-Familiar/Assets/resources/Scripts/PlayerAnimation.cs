using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator m_Animator;
    private PlayerInput m_Input;
    private PlayerMove m_Move;
    private Rigidbody2D m_Rigidbody;
    private PlayerController m_Controller;
    private Health m_Health;
    private bool dying = false;

    private static readonly int Walk = Animator.StringToHash("Walk");
    
    
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int Horizontal = Animator.StringToHash("horizontal");
    private static readonly int Vertical = Animator.StringToHash("vertical");

    private void Start()
    {
        m_Health = GameObject.Find("Health").GetComponent<Health>();
        m_Animator = GetComponent<Animator>();
        m_Input = GetComponent<PlayerInput>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Move = GetComponent<PlayerMove>();
        m_Controller = GetComponent<PlayerController>();
        dying = false;
    }
    
    private void Update()
    {
        if (PauseMenu.GameIsPaused) return;

        if (m_Health.IsDead)
        {
            m_Animator.Play("Death");
        }
        else if (m_Controller.isTakingDamage)
        {
            m_Animator.Play("Hit");
        }

        else if (m_Move.m_Dashing)
        {
            m_Animator.Play("Dash");
        }
        else if (m_Input.moveVector != Vector2.zero && m_Move.m_Puddle)
        {
            m_Animator.Play("SwimMove");
            m_Animator.SetFloat(Horizontal, m_Input.moveVector.x);
            m_Animator.SetFloat(Vertical, m_Input.moveVector.y);
        }
        else if (m_Input.moveVector != Vector2.one && m_Move.m_Puddle)
        {
            m_Animator.Play("SwimIdle");
        }
        
        else if (m_Input.moveVector != Vector2.zero)
        {
            m_Animator.Play("Walking");
            m_Animator.SetFloat(Horizontal, m_Input.moveVector.x);
            m_Animator.SetFloat(Vertical, m_Input.moveVector.y);
        }
        else
        {
            m_Animator.Play("Idle");
            
        }
    }
}
