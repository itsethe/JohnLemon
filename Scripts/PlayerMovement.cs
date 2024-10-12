using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 movement;
    Animator animator;
    Quaternion rotation = Quaternion.identity;
    public float turnspeed = 20;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0, vertical);
        movement.Normalize();
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        animator.SetBool("isWalking", isWalking);
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnspeed*Time.deltaTime,0);
        rotation=Quaternion.LookRotation(desiredForward);

    }
    void OnAnimatorMove(){
        rb.MovePosition(rb.position+movement*animator.deltaPosition.magnitude);
        rb.MoveRotation(rotation);
    }
}
