using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class ColonyController : MonoBehaviour
{
    public LevelDiagnostics levelDiagnostics;
    public float powerCost;
    public bool lightStatus = true;
    public Color on;
    public Color off;
    public Text text;
    public bool locked;
    public Flowchart chart;
    public void ToggleOxygen()
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
        Debug.Log("oxygen on");
        lightStatus = true;
        levelDiagnostics.power -= powerCost;

        var colors = GetComponent<Button>().colors;
        colors.normalColor = on;
        GetComponent<Button>().colors = colors;
        text.text = "Turn Off";
    }
    void TurnOffLight(){
        Debug.Log("oxygen off");
        lightStatus = false;
        levelDiagnostics.power += powerCost;
        var colors = GetComponent<Button>().colors;
        colors.normalColor = off;
        GetComponent<Button>().colors = colors;
        text.text = "Turn On";
    }
}
