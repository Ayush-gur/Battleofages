using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptablePlayerMovement : ScriptableObject
{
    //movement
    public string horizontalInputName;
    public string verticalInputName;
    public string jumpInputName;
    public string BlockInputName;

    //attacks
    public string LeftPunchInputName;
    public string RightPunchInputName;
    public string KickInputName;

}
