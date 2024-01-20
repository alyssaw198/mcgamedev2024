using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] Backpack backpack = null;
    private GameObject itemInRange = null;

    private void Update()
    {
        if (itemInRange != null && Input.GetKeyDown(KeyCode.E))
        {
            PickupItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            itemInRange = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == itemInRange)
        {
            itemInRange = null;
        }
    }

    private void PickupItem()
    {
        if (backpack != null && itemInRange != null)
        {
            backpack.UpdateKeys(1); // Assuming each item adds one key.
            Destroy(itemInRange); // Or handle the pickup logic
            itemInRange = null;
        }
    }
}
