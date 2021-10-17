using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrumpkinAnimations : MonoBehaviour
{
    private bool playerClose;
    private bool sus;
    private Animator m_Animator;
    private PlayerMove m_Move;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Move = GetComponent<PlayerMove>();
    }


    void Update()
    {
        if (m_Move.pumpkin)
        {
            m_Animator.Play("GrumpkinScared");
        }
        else
        {
            m_Animator.Play("GrumpkinIdle");
        }
    }
}
