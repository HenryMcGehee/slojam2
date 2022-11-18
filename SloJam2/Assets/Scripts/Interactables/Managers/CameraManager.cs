using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public GameObject bunkerCam;
    public GameObject vrCam;
    public List<Canvas> canvas;
    void Start()
    {
        foreach (var item in canvas)
        {
            item.worldCamera = bunkerCam.GetComponent<Camera>();
        }
    }
    public void SwitchToBunker(){
        foreach (var item in canvas)
        {
            item.worldCamera = bunkerCam.GetComponent<Camera>();
        }
        bunkerCam.SetActive(true);
        vrCam.SetActive(false);
    }
    public void SwitchToVR(){
        foreach (var item in canvas)
        {
            item.worldCamera = vrCam.GetComponent<Camera>();
        }
        vrCam.SetActive(true);
        bunkerCam.SetActive(false);
    }
}
