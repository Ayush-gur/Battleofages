using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask otherPlayer;

    private PlayerHealth playerHealth; 

    //used in player controls and damage
    public ScriptablePlayerMovement playerAttackNames; //holds all the names of character inputs

    private int LeftPunchDamage = 1;
    private int RightPunchDamage = 1;
    private int KickDamage = 2;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(playerAttackNames.LeftPunchInputName))
        {
            LeftPunch();

        }
        if (Input.GetButtonDown(playerAttackNames.KickInputName))
        {
            Kick();
        }
        if (Input.GetButtonDown(playerAttackNames.RightPunchInputName))
        {
            RightPunch();
        }
    }

    void LeftPunch()
    {
        Collider[] hitOtherPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, otherPlayer);

        foreach (Collider enemy in hitOtherPlayer)
        {
            Debug.Log("Lpunch");
            playerHealth.TakeDamage(LeftPunchDamage);
        }
    }

    void Kick()
    {
        Collider[] hitOtherPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, otherPlayer);

        foreach (Collider enemy in hitOtherPlayer)
        {
            Debug.Log("Kicked");
            playerHealth.TakeDamage(KickDamage);
        }
    }

    void RightPunch()
    {
        Collider[] hitOtherPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, otherPlayer);

        foreach (Collider enemy in hitOtherPlayer)
        {
            Debug.Log("RPunch");
            playerHealth.TakeDamage(RightPunchDamage);
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
