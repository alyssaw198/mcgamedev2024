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


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        
    }

    void FixedUpdate(){
        Move();
    }

    void ProcessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move(){
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
}
