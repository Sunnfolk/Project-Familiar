using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestScipt : MonoBehaviour
{
    private float m_SizeIncrease =1f;

    private float m_Move;
    void Update()
    {
        m_Move = m_SizeIncrease * 0.5f;
        transform.localScale = new Vector2(1, m_SizeIncrease);
        transform.localPosition = new Vector2(-12, m_Move);
        if (Keyboard.current.gKey.isPressed)
        {
            m_SizeIncrease += 0.1f;
        }
        if (Keyboard.current.vKey.isPressed)
        {
            m_SizeIncrease -= 0.1f;
        }
    }
}
