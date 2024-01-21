using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private Sprite sprite;

    private InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collider belongs to the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with Player detected.");
            inventoryManager.AddItem(itemName, sprite);
            Destroy(gameObject);
        }
    }
}
