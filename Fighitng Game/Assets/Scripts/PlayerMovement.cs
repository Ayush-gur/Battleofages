using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;
    [SerializeField] private string inputNameJump;

    private Rigidbody rb;

    private float inputHorizontal;
    private float inputVertical;
    private float inputJump;
    public float jumpForce = 10f;
    private bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw(inputNameHorizontal);
        inputVertical = Input.GetAxisRaw(inputNameVertical);
        if (Input.GetButtonDown(inputNameJump) && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(inputHorizontal * speed * Time.fixedDeltaTime, rb.velocity.y, inputVertical * speed * Time.fixedDeltaTime);
    }

    private void Jump()
    {

        rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
