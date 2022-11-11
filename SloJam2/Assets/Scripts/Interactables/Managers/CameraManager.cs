using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject bunkerCam;
    public GameObject vrCam;
    public void SwitchToBunker(){
        bunkerCam.SetActive(true);
        vrCam.SetActive(false);
    }
    public void SwitchToVR(){
        Debug.Log("butt");
        vrCam.SetActive(true);
        bunkerCam.SetActive(false);
    }
}
