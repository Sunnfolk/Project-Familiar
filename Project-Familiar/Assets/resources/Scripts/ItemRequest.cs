using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemRequest : MonoBehaviour
{
    [SerializeField]private float aMeterDecrPerObj = 1;
    [SerializeField] private float aMeterDecrAll3 = 10;
    private AngerMeter m_AngerMeter;
    private CauldronController m_CauldronController;
    public GameObject[] requestItems;
    public Transform[] spawnPoints;
    private int m_NumberOfItems;
    private List<GameObject> m_SpawnedItems = new List<GameObject>();
    private GameObject m_RightGameObject;
    private bool m_Success;
    private GameObject m_ObejctToDestroy;
    private bool m_Wrong;
    private int m_NumberOfSuccess;

    private void Start()
    {
        m_CauldronController = GetComponent<CauldronController>();
        m_AngerMeter = GameObject.Find("AngerMeter").GetComponent<AngerMeter>();
        SpawnRequests();
    }

    void Update()
    {
        if (m_Success)
        {
            m_AngerMeter.meter -= aMeterDecrPerObj;
            m_Wrong = false;
            m_ObejctToDestroy = GameObject.FindWithTag(m_RightGameObject.tag);
            m_SpawnedItems.Remove(m_ObejctToDestroy);
            Destroy(m_ObejctToDestroy);
            Destroy(m_RightGameObject);
            m_Success = false;
            m_NumberOfSuccess++;
        }

        if (m_NumberOfSuccess == 3)
        {
            m_NumberOfSuccess = 0;
            m_AngerMeter.meter -= aMeterDecrAll3;
            SpawnRequests();
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
                m_Success = true;
                
                print("succ");
            }
            else
            {
                m_Wrong = true;
            }
        }
    }

    private void SpawnRequests()
    {
        for (int item = 0; item < 3; item++)
        {
            m_NumberOfItems = Random.Range(0, requestItems.Length);
            var clone = Instantiate(requestItems[m_NumberOfItems], spawnPoints[item].position, new Quaternion()); 
            m_SpawnedItems.Add(clone);
        }
    }
}
