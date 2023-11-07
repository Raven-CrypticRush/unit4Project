using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //VARIABLES

    [Header("Movement")]
    public float moveSpeed;
    public float turnSpeed;
    public float jumpForce;
    public bool isOnGround = true;
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Forward and Backward Movement

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.left * moveSpeed * horizontalInput * Time.deltaTime);



        //Jumping

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollision(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
