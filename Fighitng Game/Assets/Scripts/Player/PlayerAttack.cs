using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask otherPlayer;
    public Collider[] hitOtherPlayer;

    //used in player controls and damage
    public ScriptablePlayerMovement playerAttackNames; //holds all the names of character inputs

    private int LeftPunchDamage = 1;
    private int RightPunchDamage = 1;
    private int KickDamage = 2;
    public bool canblock;

    // private Viking viking;
    // private Gladiator gladiator;

    void Start()
    {
       
      
        
        //if viking/Gladiator script exits on the charcter, get component
    }
    // Update is called once per frame
    void Update()
    {
        hitOtherPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, otherPlayer);
    }



    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
