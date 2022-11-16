using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraOnHighlight : MonoBehaviour, ISelectHandler
{
    public ComputerCamMove cam;
    public ComputerHighLight highLight;
    public int selectionNum;
    public Transform loc;
    public Transform lookAt;

    public void OnSelect(BaseEventData eventData)
    {
        highLight.UpdateMaterials(selectionNum);
        cam.GetComponent<ComputerCamMove>().camLoc = loc;
        cam.GetComponent<ComputerCamMove>().camLookAt = lookAt;
    }
}
