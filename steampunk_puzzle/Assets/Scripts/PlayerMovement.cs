using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public Animator animator;


    private float minX, maxX, minY, maxY;

    void Start()
    {
        // Define screen boundaries in world coordinates
        minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.26f, 0)).y;
        maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        
    }

    void FixedUpdate()
    {
        Move();
        ClampPosition(); // Added this function to clamp the position
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        animator.SetFloat("H_Speed", moveDirection.x * moveSpeed);
        animator.SetBool("V_Speed", Mathf.Abs(moveDirection.y * moveSpeed) > 0);
            
        /*if (Mathf.Abs(moveDirection.y) > 0 && moveDirection.x > 0){
            animator.SetFloat("Speed", Mathf.Abs(moveDirection.y) * moveDirection.x * moveSpeed);
        } else if (Mathf.Abs(moveDirection.y) > 0) {
            animator.SetFloat("Speed", Mathf.Abs(moveDirection.y) * moveSpeed);
        } else {
            animator.SetFloat("Speed", moveDirection.x * moveSpeed);
        } ;*/ 
        
    }

    void ClampPosition()
    {
        // Clamp the player's position within the screen boundaries
        float clampedX = Mathf.Clamp(rb.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(rb.position.y, minY, maxY);

        // Update the Rigidbody position with clamped values
        rb.position = new Vector2(clampedX, clampedY);
    }
}
