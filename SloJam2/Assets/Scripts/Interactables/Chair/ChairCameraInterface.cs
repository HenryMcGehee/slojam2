using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairCameraInterface : MonoBehaviour
{
    public CameraManager camM;

    public void SwitchCam(){
        Debug.Log("fuck");
        camM.SwitchToVR();
    }
}
