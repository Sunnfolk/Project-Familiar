using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] spawnItems;
    public Transform[] spawnPoints;

    void Update()
    {
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            for (int i = 0; i < spawnItems.Length; i++)
            {
                var clone = Instantiate(spawnItems[i], spawnPoints[i].position, new Quaternion());
                Destroy(clone, 30f);
            }
        }
    }
}
