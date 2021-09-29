using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class ItemRequest : MonoBehaviour
{
    public GameObject[] requestItems;
    private int m_NumberOfItems;
    private GameObject m_CollidingObject;
    void Update()
    {
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
           
            /*for (int item = 0; item < 3; item++)
            {
                m_NumberOfItems = Random.Range(0, requestItems.Length);
                Instantiate(requestItems[m_NumberOfItems], GameObject.FindGameObjectWithTag("RSpawnpoint"+item).transform.position, new Quaternion());
            }*/
            Instantiate(m_CollidingObject, GameObject.FindGameObjectWithTag("RSpawnpoint"+0).transform.position, new Quaternion());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        m_CollidingObject = other.gameObject;
    }
}
