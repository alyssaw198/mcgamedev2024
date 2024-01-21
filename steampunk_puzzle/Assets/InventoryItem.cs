using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has a specific tag
        if (collision.gameObject.CompareTag("Banana2"))
        {
            // Destroy both draggable objects
            Debug.Log("Collided with Banana2!");
            Vector2 collisionPoint = collision.contacts[0].point;
            Destroy(gameObject);
            Destroy(collision.gameObject);

            // Instantiate a new asset or perform any other logic
            Debug.Log("MERGE INTO NEW OBJECT!");
        }
    }
}
