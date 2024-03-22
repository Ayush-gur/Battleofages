using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask otherPlayer;
    Collider[] hitOtherPlayer;

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
        hitOtherPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, otherPlayer);
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
        foreach (Collider enemy in hitOtherPlayer)
        {
            PlayerHealth otherPlayerHealth = enemy.GetComponent<PlayerHealth>();

            Debug.Log("Lpunch");
            otherPlayerHealth.TakeDamage(LeftPunchDamage);
        }
    }

    void Kick()
    {
        
        foreach (Collider enemy in hitOtherPlayer)
        {
            PlayerHealth otherPlayerHealth = enemy.GetComponent<PlayerHealth>();

            Debug.Log("Kicked");
            otherPlayerHealth.TakeDamage(KickDamage);
        }
    }

    void RightPunch()
    {
       

        foreach (Collider enemy in hitOtherPlayer)
        {
            PlayerHealth otherPlayerHealth = enemy.GetComponent<PlayerHealth>();
            Debug.Log("RPunch");
            otherPlayerHealth.TakeDamage(RightPunchDamage);
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
