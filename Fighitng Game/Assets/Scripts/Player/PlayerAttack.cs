using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public Transform attackPointKick;
    private float attackRange = 0.5f;
    public LayerMask otherPlayer;
    public Collider[] hitOtherPlayer;
    private Collider[] hitOtherPlayerKick;


    //used in player controls and damage
    public ScriptablePlayerMovement playerAttackNames; //holds all the names of character inputs
    private AnimationStateController Animate;
    private SoundManager sm;

    //this is done to check the bool isMoving, that was attack animation can be prioritized over movement
    private PlayerMovement playerMovement;

    private int LeftPunchDamage = 3;
    private int RightPunchDamage = 3;
    private int KickDamage = 5;
    public bool isBlocking = false;
    public float BlockTimer = 0f;
    private Coroutine attackTimerCoroutine;
    private float attackTime;

    //this checks which character it is, this is done to get the right frames for the couroutine
    private Gladiator gladiator;
    private Viking Viking;
    private Monk monk;

    void Start()
    {
        Animate = GetComponent<AnimationStateController>();
        sm = GetComponent<SoundManager>();
        playerMovement = GetComponent<PlayerMovement>();

        monk = GetComponent<Monk>();
        gladiator = GetComponent<Gladiator>();
        Viking = GetComponent<Viking>();
       
    }
    // Update is called once per frame
    void Update()
    {
        hitOtherPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, otherPlayer);
        hitOtherPlayerKick = Physics.OverlapSphere(attackPoint.position, attackRange, otherPlayer);

    }
    private void FixedUpdate()
    {

        if (Input.GetButtonDown(playerAttackNames.LeftPunchInputName))
        {
            playerMovement.isAttacking = true;
            LeftPunch();

        }
        if (Input.GetButtonDown(playerAttackNames.KickInputName))
        {
            playerMovement.isAttacking = true;
            Kick();
        }
        if (Input.GetButtonDown(playerAttackNames.RightPunchInputName))
        {
            playerMovement.isAttacking = true;
            RightPunch();
        }
        if (Input.GetButtonDown(playerAttackNames.BlockInputName))
        {
            playerMovement.isAttacking = true;
            Block();
        }
        else
        {
            isBlocking = false;
        }
    }
    public void Block()
    {
        isBlocking = true;
        Animate.Block();
    }
    public void LeftPunch()
    {
        playerMovement.isMoving = false;
        playerMovement.isAttacking = true;
        Animate.StopWalking();
        Animate.LeftPunch();

        if(Viking != null)
        {
            attackTime = 0.32f;
        }
        else if(gladiator != null)
        {
            attackTime = 0.43f;
        }
        else if(monk != null)
        {
            attackTime = 0.22f;
        }


        foreach (Collider enemy in hitOtherPlayer)
        {

            PlayerHealth otherPlayerHealth = enemy.GetComponent<PlayerHealth>();
            PlayerAttack otherPlayerBlock = enemy.GetComponent<PlayerAttack>();
            if (otherPlayerBlock.isBlocking == false)
            {
                Debug.Log("Lpunch");
                otherPlayerHealth.TakeDamage(LeftPunchDamage);
            }
        }

        attackTimerCoroutine = StartCoroutine(attackAnimationTimer());
    }
    public void RightPunch()
    {
        playerMovement.isMoving = false;
        playerMovement.isAttacking = true;
        Animate.StopWalking();
        Animate.RightPunch();
        if (Viking != null)
        {
            attackTime = 0.29f;
        }
        else if (gladiator != null)
        {
            attackTime = 0.43f;
        }
        else if (monk != null)
        {
            attackTime = 0.26f;
        }

        foreach (Collider enemy in hitOtherPlayer)
        {

            PlayerHealth otherPlayerHealth = enemy.GetComponent<PlayerHealth>();
            PlayerAttack otherPlayerBlock = enemy.GetComponent<PlayerAttack>();
            if (otherPlayerBlock.isBlocking == false)
            {
                Debug.Log("Rpunch");
                otherPlayerHealth.TakeDamage(RightPunchDamage);
            }

        }

        attackTimerCoroutine = StartCoroutine(attackAnimationTimer());
    }

    void Kick()
    {
        playerMovement.isMoving = false;
        playerMovement.isAttacking = true;
        Animate.StopWalking();
        Animate.Kick();
        if (Viking != null)
        {
            attackTime = 0.37f;
        }
        else if (gladiator != null)
        {
            attackTime = 0.36f;
        }
        else if (monk != null)
        {
            attackTime = 0.20f;
        }
        foreach (Collider enemy in hitOtherPlayerKick)
        {
            PlayerHealth otherPlayerHealth = enemy.GetComponent<PlayerHealth>();
            PlayerAttack otherPlayerBlock = enemy.GetComponent<PlayerAttack>();
            if (otherPlayerBlock.isBlocking == false)
            {
                Debug.Log("Kicked");
                otherPlayerHealth.TakeDamage(KickDamage);
            }
            else
            {
                Debug.Log("Blocked");
            }
        }
        attackTimerCoroutine = StartCoroutine(attackAnimationTimer());
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(attackPointKick.position, attackRange);
    }

    IEnumerator attackAnimationTimer()
    {
        yield return new WaitForSeconds(attackTime);
        Animate.animator.SetInteger("isAttacking", 0);
        playerMovement.isAttacking = false;
    }
}
