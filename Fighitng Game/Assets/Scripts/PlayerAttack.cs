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
    [SerializeField] private string inputNameLightPunch;
    private int LightPunchDamage = 1;
    [SerializeField] private string inputNameSpecialAttack;
    private int SpecialAttackDamage = 3;
    [SerializeField] private string inputNameKick;
    private int KickDamage = 2;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(inputNameLightPunch))
        {
            LightPunch();

        }
        if (Input.GetButtonDown(inputNameKick))
        {
            Kick();
        }
        if (Input.GetButtonDown(inputNameSpecialAttack))
        {
            SpecialAttack();
        }
    }

    void LightPunch()
    {
        Collider[] hitOtherPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, otherPlayer);

        foreach (Collider enemy in hitOtherPlayer)
        {
            Debug.Log("Lpunch");
            playerHealth.TakeDamage(LightPunchDamage);
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

    void SpecialAttack()
    {
        Collider[] hitOtherPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, otherPlayer);

        foreach (Collider enemy in hitOtherPlayer)
        {
            Debug.Log("SAttack");
            playerHealth.TakeDamage(SpecialAttackDamage);
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
