using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraOnHighlight : MonoBehaviour, ISelectHandler
{
    public ComputerCamMove cam;
    public Transform loc;
    public Transform lookAt;

    public void OnSelect(BaseEventData eventData)
    {
        cam.GetComponent<ComputerCamMove>().camLoc = loc;
        cam.GetComponent<ComputerCamMove>().camLookAt = lookAt;
    }
}
