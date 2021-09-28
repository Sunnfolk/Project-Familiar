using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchAnimation : MonoBehaviour
{
    private Animator m_Animator;
    private CauldronController m_CauldronController;
    private bool m_Switch1;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_CauldronController = GameObject.Find("Cauldron").GetComponent<CauldronController>();
    }
    
    void Update()
    {
        if (m_CauldronController.m_Switch1 && !m_Switch1)
        {
            m_Animator.Play("IdleToAngry");
            m_Switch1 = true;
            print("test");
        }
       /* else if (m_CauldronController.m_Switch1 && m_Switch1)
        {
            m_Animator.Play("Angry");
        }
        else
        {
            m_Animator.Play("Idle");
        }*/
    }
}
