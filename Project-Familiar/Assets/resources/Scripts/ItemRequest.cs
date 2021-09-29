using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class ItemRequest : MonoBehaviour
{
    public GameObject[] requestItems;
    private int m_NumberOfItems;
    private GameObject m_CollidingObject;
    private List<GameObject> _spawnedItems = new List<GameObject>();

    void Update()
    {
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {

            for (int item = 0; item < 3; item++)
            {
                m_NumberOfItems = Random.Range(0, requestItems.Length);
                var clone = Instantiate(requestItems[m_NumberOfItems],
                    GameObject.FindGameObjectWithTag("RSpawnpoint" + item).transform.position, new Quaternion()); 
                _spawnedItems.Add(clone);
                
                //if (m_CollidingObject == null) return;
                //Instantiate(m_CollidingObject, GameObject.FindGameObjectWithTag("RSpawnpoint"+0).transform.position, new Quaternion());
            }
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            print(m_CollidingObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (var item in _spawnedItems)
        {
            if (other.CompareTag(item.tag))
            {
                Destroy(other);
                
            }
        }
    }
}
