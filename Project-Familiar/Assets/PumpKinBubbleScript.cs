using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpKinBubbleScript : MonoBehaviour
{
    private Animator m_Animator;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.Play("GrumpkinSus");
    }
}
