using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    public LevelDiagnostics levelDiagnostics;
    public float powerCost;
    public GameObject lights;
    public bool lightStatus = true;
    public Color on;
    public Color off;
    public void ToggleLight()
    {
        if(!lightStatus){
            TurnOnLight();
            var colors = GetComponent<Button>().colors;
            colors.normalColor = on;
            GetComponent<Button>().colors = colors;
        }
        else{
            TurnOffLight();
            var colors = GetComponent<Button>().colors;
            colors.normalColor = off;
            GetComponent<Button>().colors = colors;
        }
    }
    void TurnOnLight(){
        Debug.Log("ripperrooo");
        lights.SetActive(true);
        lightStatus = true;
        levelDiagnostics.power -= powerCost;
    }
    void TurnOffLight(){
        Debug.Log("ripper");
        lights.SetActive(false);
        lightStatus = false;
        levelDiagnostics.power += powerCost;
    }
}
