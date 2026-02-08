using UnityEngine;
using UnityEngine.InputSystem;

public class player_harvesting : MonoBehaviour
{
    private GameObject currentResource;
    public InventoryManager inventory;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ressources"))
            currentResource = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ressources") && currentResource == other.gameObject)
            currentResource = null;
    }

    void Update()
    {
        if (currentResource == null) return;

        // Utilise le nouveau Input System
        if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
        {
            Debug.Log("Harvested resource: " + currentResource.name);
            inventory.AddItem(AllItems.Wood); 
            Destroy(currentResource);
            currentResource = null;
        }
    }
}