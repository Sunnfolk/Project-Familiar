using System;
using Unity.Mathematics;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject[] ItemPrefabs;
    public GameObject currentItem;
    public bool canPickup;
    public bool canDrop;

    private PlayerInput _input;

   [SerializeField] private GameObject prefabObject;
    [SerializeField] private GameObject colliderObject;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (_input.interact && canPickup && currentItem == null)
        {
            currentItem = prefabObject;
            Destroy(colliderObject);
            
            prefabObject = null;
            colliderObject = null;
            canDrop = true;
        }
        else if (_input.interact && canDrop)
        {
            Instantiate(currentItem, transform.position, quaternion.identity);
            currentItem = null;
            canDrop = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (currentItem != null) return;
        
        foreach (var item in ItemPrefabs)
        {
            if (other.CompareTag(item.tag))
            {
                canPickup = true;
                prefabObject = item;
                colliderObject = other.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canPickup = false;
        prefabObject = null;
        colliderObject = null;
    }
}
