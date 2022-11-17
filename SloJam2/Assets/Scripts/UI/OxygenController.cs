using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenController : MonoBehaviour
{
    public LevelDiagnostics levelDiagnostics;
    public float powerCost;
    public GameObject oxygenIndicator;
    public bool lightStatus = true;
    public Color on;
    public Color off;
    public Text text;
    public void ToggleOxygen()
    {
        if(!lightStatus){
            TurnOnLight();
        }
        else{
            TurnOffLight();
        }
    }
    void TurnOnLight(){
        Debug.Log("oxygen on");
        oxygenIndicator.SetActive(true);
        lightStatus = true;
        levelDiagnostics.power -= powerCost;

        var colors = GetComponent<Button>().colors;
        colors.normalColor = on;
        GetComponent<Button>().colors = colors;
        text.text = "Turn Off";
    }
    void TurnOffLight(){
        Debug.Log("oxygen off");
        oxygenIndicator.SetActive(false);
        lightStatus = false;
        levelDiagnostics.power += powerCost;

        var colors = GetComponent<Button>().colors;
        colors.normalColor = off;
        GetComponent<Button>().colors = colors;
        text.text = "Turn On";
    }
}
