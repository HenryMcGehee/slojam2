using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ChairCameraInterface : MonoBehaviour
{
    public CameraManager camM;
    public Flowchart chart;
    public int convoIndex;

    public void SwitchCam(){
        chart.ExecuteBlock(convoIndex.ToString());
        //camM.SwitchToVR();
    }
}
