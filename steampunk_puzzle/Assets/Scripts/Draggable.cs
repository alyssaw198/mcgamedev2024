using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has a specific tag
        if (collision.gameObject.CompareTag("Combine"))
        {
            // Destroy both draggable objects
            Debug.Log("Collided with another Draggable!");
            Vector2 collisionPoint = collision.contacts[0].point;
            Destroy(gameObject);
            Destroy(collision.gameObject);

            // Instantiate a new asset or perform any other logic
            InstantiateNewAsset(collisionPoint);
        }
    }

    // Example method to instantiate a new asset
    void InstantiateNewAsset(Vector2 position)
    {
        Sprite newSprite = Resources.Load<Sprite>("Prefabs/obj3");
        if (newSprite == null)
        {
            Debug.LogError("Failed to load sprite: Prefabs/obj3");
            return;
        }

        GameObject newAsset = new GameObject("Triangle");
        SpriteRenderer spriteRenderer = newAsset.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;

        // Add a 2D Rigidbody to the new GameObject
        Rigidbody2D rigidbody2D = newAsset.AddComponent<Rigidbody2D>();
        // Optionally, adjust Rigidbody settings (e.g., gravity, constraints)

        // Add a BoxCollider2D as a square hitbox
        BoxCollider2D boxCollider = newAsset.AddComponent<BoxCollider2D>();
        // Set the size of the BoxCollider2D based on the sprite's bounds
        boxCollider.size = spriteRenderer.bounds.size;
        rigidbody2D.gravityScale = 0;
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        newAsset.tag = "Combine";

        // Set the position of the new asset
        newAsset.transform.position = position;

        // Optionally, add the Draggable component
        Draggable newDraggable = newAsset.AddComponent<Draggable>();
    }
}
