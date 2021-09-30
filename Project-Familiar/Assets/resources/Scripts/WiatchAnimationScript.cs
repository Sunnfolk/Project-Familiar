using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiatchAnimationScript : MonoBehaviour
{
    private Animator m_Animator;
    private CauldronController m_Cauldron;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Cauldron = GetComponent<CauldronController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Cauldron.stage3)
        {
            m_Animator.Play("WitchIdleStage3");
        }
        else if (m_Cauldron.stage2)
        {
            m_Animator.Play("WitchIdleStage2");
        }
        else if (m_Cauldron.stage1)
        {
            m_Animator.Play("WitchIdleStage1");
        }
    }
}
