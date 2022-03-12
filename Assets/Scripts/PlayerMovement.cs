using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    private void Reset()
    {
        Debug.Log("reset");
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if(Input.GetButtonDown("Jump") && IsGround())
        {
            Jump();
        }
    }
     void Jump()
     {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
     }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.transform.parent.gameObject.name);
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool IsGround()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
