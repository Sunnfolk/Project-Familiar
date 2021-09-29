using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class ItemRequest : MonoBehaviour
{
    public GameObject[] requestItems;
    private int m_NumberOfItems;
    private List<GameObject> m_SpawnedItems = new List<GameObject>();
    private GameObject m_RightGameObject;
    private bool m_Succes;
    private GameObject m_ObejctToDestroy;

    void Update()
    {
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            for (int item = 0; item < 3; item++)
            {
                m_NumberOfItems = Random.Range(0, requestItems.Length);
                var clone = Instantiate(requestItems[m_NumberOfItems],
                    GameObject.FindGameObjectWithTag("RSpawnpoint" + item).transform.position, new Quaternion()); 
                m_SpawnedItems.Add(clone);
            }
        }

        if (m_Succes)
        {
            m_ObejctToDestroy = GameObject.FindWithTag(m_RightGameObject.tag);
            m_SpawnedItems.Remove(m_ObejctToDestroy);
            Destroy(m_ObejctToDestroy);
            Destroy(m_RightGameObject);
            m_Succes = false;
        }
       

        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            print("Destroy "+m_ObejctToDestroy);
            print("Right "+m_RightGameObject);
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
                print("FALSE");
            }
        }
    }
}
