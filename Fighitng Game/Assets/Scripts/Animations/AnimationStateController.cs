using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame

    public void WalkingForward()
    {
        animator.SetInteger("isMoving", 2);
    }
    public void WalkingBackward()
    {
        animator.SetInteger("isMoving", 1);

    }
    public void StopWalking()
    {
        animator.SetInteger("isMoving", 0);
    }

    public void LeftPunch()
    {
        animator.SetInteger("isAttacking", 1);
    }

    public void RightPunch()
    {
        animator.SetInteger("isAttacking", 2);

    }

    public void Kick()
    {
        animator.SetInteger("isAttacking", 3);
    }

}
