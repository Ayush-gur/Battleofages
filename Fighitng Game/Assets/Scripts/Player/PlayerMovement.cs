using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ScriptablePlayerMovement playerMovementNames; //holds all the names of character inputs

    [SerializeField] private float speed;

    private Rigidbody rb;
    public SoundManager sm;

    private float inputHorizontal;
    private float inputVertical;
    public float jumpForce = 10f;
    //temp public 
    public  bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sm = GameObject.FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw(playerMovementNames.horizontalInputName);
        inputVertical = Input.GetAxisRaw(playerMovementNames.verticalInputName);
        if (Input.GetButtonDown(playerMovementNames.jumpInputName) && isGrounded)
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
