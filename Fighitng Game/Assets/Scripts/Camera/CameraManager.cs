using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineFreeLook[] cameras;

    public CinemachineFreeLook closeRangeCam;
    public CinemachineFreeLook midRangeCam;
    public CinemachineFreeLook longRangeCam;

    public CinemachineFreeLook startCamera;
    private CinemachineFreeLook currentCam;

    private void Start()
    {
        currentCam = startCamera;

        for(int i =0; i< cameras.Length; i++)
        {
            if (cameras[i] == currentCam)
            {
                cameras[i].Priority = 20;
            }
            else
            {
                cameras[i].Priority = 10;
            }
        }
    }
    
    public void SwichCamera()
    {

    }



}
