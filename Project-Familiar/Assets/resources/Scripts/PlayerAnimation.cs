using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator m_Animator;
    private PlayerInput m_Input;
    private PlayerMove m_Move;
    private Rigidbody2D m_Rigidbody;

    private static readonly int Walk = Animator.StringToHash("Walk");
    
    
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int Horizontal = Animator.StringToHash("horizontal");
    private static readonly int Vertical = Animator.StringToHash("vertical");

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Input = GetComponent<PlayerInput>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (m_Input.moveVector != Vector2.zero)
        {
            m_Animator.SetFloat(Vertical, m_Input.moveVector.y);
            m_Animator.SetFloat(Horizontal, m_Input.moveVector.x);
            m_Animator.SetBool(IsWalking, true);
        }
        else
        {
            m_Animator.SetBool(IsWalking, false);
        }
    }
}
