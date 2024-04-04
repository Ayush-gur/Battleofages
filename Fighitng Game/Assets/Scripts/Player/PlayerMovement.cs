using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ScriptablePlayerMovement playerMovementNames; //holds all the names of character inputs
    private AnimationStateController Animation;
    private Transform opponent;

    [SerializeField] private float speed;

    private Rigidbody rb;
    public SoundManager sm;

    private float inputHorizontal;
    private float inputVertical;
    public float jumpForce = 10f;

    private  bool isGrounded = true;
    public bool isMoving = false;
    public bool isAttacking = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sm = GameObject.FindObjectOfType<SoundManager>();
        Animation = GetComponent<AnimationStateController>();
        if (gameObject.tag == "Player 1")
        {
            opponent = GameObject.FindGameObjectWithTag("Player 2").transform;
        }
        else if (gameObject.tag == "Player 2")
        {
            opponent = GameObject.FindGameObjectWithTag("Player 1").transform;
        }
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw(playerMovementNames.horizontalInputName);
        inputVertical = Input.GetAxisRaw(playerMovementNames.verticalInputName);
        if (Input.GetButtonDown(playerMovementNames.jumpInputName))
        {
            Jump();
        }
            if (inputHorizontal != 0 || inputVertical != 0)
        {
            isMoving = true;

            if (inputHorizontal > 0)
            {
                Debug.Log("Moving forwards");
                Animation.WalkingForward();
            }
            else if (inputHorizontal < 0)
            {
                Debug.Log("Moving backwards");
                Animation.WalkingBackward();
            }
          
        }
        else
        {
            Animation.StopWalking();
            isMoving = false;
        }

        Vector3 directionToOpponent = opponent.position - transform.position;
        directionToOpponent.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(directionToOpponent);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
    }

    private void FixedUpdate()
    {
        if (!isAttacking) 
        {
            isMoving = true;
            rb.velocity = new Vector3(inputHorizontal * speed * Time.fixedDeltaTime, rb.velocity.y, inputVertical * speed * Time.fixedDeltaTime);

        }
    }
    private void MovingHorizontal()
    {
        isMoving = true;
       
        if (inputHorizontal > 0)
        {
            Debug.Log("Moving forwards");
            Animation.WalkingForward();
        }
        else if (inputHorizontal < 0)
        {
            Debug.Log("Moving backwards");
            Animation.WalkingBackward();
        }
        
    }
    private void MovingVertical()
    {
        isMoving = true;
        
    }
    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
