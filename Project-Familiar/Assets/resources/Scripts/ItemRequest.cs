using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class ItemRequest : MonoBehaviour
{
    private CauldronController m_CauldronController;
    public GameObject[] requestItems;
    public Transform[] spawnPoints;
    private int m_NumberOfItems;
    private List<GameObject> m_SpawnedItems = new List<GameObject>();
    private GameObject m_RightGameObject;
    private bool m_Succes;
    private GameObject m_ObejctToDestroy;
    private bool m_Wrong;

    private void Start()
    {
        m_CauldronController = GetComponent<CauldronController>();
    }

    void Update()
    {
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            for (int item = 0; item < 3; item++)
            {
                m_NumberOfItems = Random.Range(0, requestItems.Length);
                var clone = Instantiate(requestItems[m_NumberOfItems], spawnPoints[item].position, new Quaternion()); 
                m_SpawnedItems.Add(clone);
            }
        }

        if (m_Succes)
        {
            m_Wrong = false;
            m_ObejctToDestroy = GameObject.FindWithTag(m_RightGameObject.tag);
            m_SpawnedItems.Remove(m_ObejctToDestroy);
            Destroy(m_ObejctToDestroy);
            Destroy(m_RightGameObject);
            m_Succes = false;
        }

        if (m_Wrong)
        {
            m_CauldronController.angerIncreaseFq -= 0.5f;
            m_Wrong = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (var item in m_SpawnedItems)
        {
            if (other.CompareTag(item.tag))
            {
                m_RightGameObject = other.gameObject;
                m_Succes = true;
                
                print("succ");
            }
            else
            {
                m_Wrong = true;
            }
        }
    }
}
