using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gladiator : MonoBehaviour
{
    private AnimationStateController Animate;
    private PlayerAttack playerAttack;
    public ScriptablePlayerMovement playerAttackNames;
    private SoundManager sm;

   
    public float TimeForCombo = 0.0f;
    private Coroutine comboTimerCoroutine;
    private float comboTime;
    private bool[] comboAvailable;

    // Start is called before the first frame update
    void Start()
    {
        Animate = GetComponent<AnimationStateController>();
        playerAttack = GetComponent<PlayerAttack>();
        sm = GameObject.FindObjectOfType<SoundManager>();
        comboAvailable = new bool[3]; 
    }
    private void FixedUpdate()
    {
        if (Input.GetButtonDown(playerAttackNames.LeftPunchInputName))
        {
            GladiatorLeftPunch();
            
        }
        if (Input.GetButtonDown(playerAttackNames.KickInputName))
        {
            GladiatorKick();
        }
        if (Input.GetButtonDown(playerAttackNames.RightPunchInputName))
        {
            GladiatorRightPunch();
        }
    }

    public void GladiatorLeftPunch()
    {
        comboTime = 0.13f;
        Animate.LeftPunch();

        comboAvailable[0] = true;
        comboAvailable[1] = true;
        comboAvailable[2] = false;

        comboTimerCoroutine = StartCoroutine(ComboTimer());
        foreach (Collider enemy in playerAttack.hitOtherPlayer)
        {
            PlayerHealth otherPlayerHealth = enemy.GetComponent<PlayerHealth>();
            Debug.Log("Lpunch");
            
        }

       
    }
    public void GladiatorRightPunch()
    {
        comboTime = 0.20f;
        comboAvailable[0] = false;
        comboAvailable[1] = true;
        comboAvailable[2] = false;

        foreach (Collider enemy in playerAttack.hitOtherPlayer)
        {
            PlayerHealth otherPlayerHealth = enemy.GetComponent<PlayerHealth>();
            Debug.Log("RPunch");
            //otherPlayerHealth.TakeDamage(RightPunchDamage);
        }
    }

    void GladiatorKick()
    {
        comboTime = 0.13f;
        comboAvailable[0] = false;
        comboAvailable[1] = true;
        comboAvailable[2] = false;

        foreach (Collider enemy in playerAttack.hitOtherPlayer)
        {
            PlayerHealth otherPlayerHealth = enemy.GetComponent<PlayerHealth>();

            Debug.Log("Kicked");

            //if the player is retracting his attack, play this
            //otherPlayerHealth.TakeDamage(KickDamage);
        }
    }

    IEnumerator ComboTimer()
    {
        float timer = 0f;
        while(timer < comboTime )
        {
            if(comboAvailable[0] == true)
            {
                if (Input.GetButtonDown(playerAttackNames.LeftPunchInputName))
                {
                    Animate.Combo1();
                    break;
                }

            }
            if (comboAvailable[1] == true)
            {
                if (Input.GetButtonDown(playerAttackNames.RightPunchInputName))
                {
                    Animate.Combo2();
                    break;
                }
            }
            if (comboAvailable[2] == true)
            {
                if (Input.GetButtonDown(playerAttackNames.KickInputName))
                {
                    Animate.Combo3();
                    break;
                }
            }

            yield return null;
        }
    }
}
