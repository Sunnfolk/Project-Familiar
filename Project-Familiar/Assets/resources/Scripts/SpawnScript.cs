using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] spawnItems;
    public Transform[] spawnPoints;
    [SerializeField] private float timer = 10f;
    private float m_TimerCounter;

    private void Start()
    {
        m_TimerCounter = timer;
        SpawnItems();
    }

    void Update()
    {
        if (m_TimerCounter > 0)
        {
            m_TimerCounter -= Time.deltaTime;
        }

        if (m_TimerCounter <= 0)
        {
            m_TimerCounter = timer;
            SpawnItems();
        }
    }

    private void SpawnItems()
    {
        for (int i = 0; i < spawnItems.Length; i++)
        {
            var clone = Instantiate(spawnItems[i], spawnPoints[i].position, new Quaternion());
            Destroy(clone, timer);
        }
    }
}
