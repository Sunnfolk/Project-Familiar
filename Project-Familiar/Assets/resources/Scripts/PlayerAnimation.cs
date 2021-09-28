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

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Input = GetComponent<PlayerInput>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        m_Animator.SetFloat("vertical", m_Input.moveVector.y);
        m_Animator.SetFloat("horizontal", m_Input.moveVector.x);

        if (m_Input.moveVector != Vector2.zero)
        {
            m_Animator.Play("Walking");
        }
        else
        {
            m_Animator.Play("Idle");
        }
    }
}
