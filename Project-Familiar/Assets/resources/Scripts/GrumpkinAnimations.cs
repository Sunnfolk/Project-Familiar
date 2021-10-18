using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrumpkinAnimations : MonoBehaviour
{
    public bool playerClose;
    private bool sus;
    public bool target;
    private Animator m_Animator;
    private PlayerMove m_Move;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Move = GetComponent<PlayerMove>();
    }


    void Update()
    {
        if (playerClose)
        {
            m_Animator.Play("GrumpkinScared");
        }

        else if (target)
        {
            m_Animator.Play("GrumpkinConcerned");
        }
        else
        {
            m_Animator.Play("GrumpkinIdle");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerClose = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerClose = false;
    }
}
