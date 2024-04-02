using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    //Manages all animations here

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

    public void Block()
    {
        animator.SetInteger("isAttacking", 4);
    }

    public void Combo1()
    {
        animator.SetInteger("isCombo", 1);
    }

    public void Combo2()
    {
        animator.SetInteger("isCombo", 2);
    }
    public void Combo3()
    {
        animator.SetInteger("isCombo", 3);
    }

}
