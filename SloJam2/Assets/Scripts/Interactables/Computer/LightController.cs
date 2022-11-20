using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class LightController : MonoBehaviour
{
    public LevelDiagnostics levelDiagnostics;
    public float powerCost;
    public GameObject lights;
    public bool lightStatus;
    public bool lightOffOnStart;
    public bool locked;
    public Color on;
    public Color off;
    public Flowchart chart;
    void Start()
    {
        if(lightOffOnStart)
        {
            TurnOffLight();
        }
    }
    public void ToggleLight()
    {
        if(!lightStatus){
            TurnOnLight();
        }
        else{
            if(!locked){
                TurnOffLight();
            }
            else{
                Debug.Log("Locked");
                chart.ExecuteBlock("Locked");
                // play sound
            }
        }
    }
    void TurnOnLight(){
        Debug.Log("ripperrooo");
        lights.SetActive(true);
        lightStatus = true;
        levelDiagnostics.power -= powerCost;

        var colors = GetComponent<Button>().colors;
        colors.normalColor = on;
        GetComponent<Button>().colors = colors;
    }
    void TurnOffLight(){
        Debug.Log("ripper");
        lights.SetActive(false);
        lightStatus = false;
        levelDiagnostics.power += powerCost;

        var colors = GetComponent<Button>().colors;
        colors.normalColor = off;
        GetComponent<Button>().colors = colors;
    }
}
