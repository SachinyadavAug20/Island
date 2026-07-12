using UnityEngine;
using UnityEngine.InputSystem;

public class WoodPickup : MonoBehaviour
{
    private InventoryManager inventory;
    
    private bool isPlayerInRange = false;

    void Start()
    {
        inventory = Object.FindFirstObjectByType<InventoryManager>();
    }

    void Update()
    {
        if (isPlayerInRange && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            HarvestTree();
        }
    }

    void HarvestTree()
    {
        if (inventory != null)
        {
            inventory.AddWood(1);
        }
        
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
