using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    public LevelDiagnostics levelDiagnostics;
    public float powerCost;
    public List<GameObject> lights;
    public bool lightStatus = true;
    public Color on;
    public Color off;
    public void ToggleLight(int i)
    {
        if(!lightStatus){
            TurnOnLight(i);
            var colors = GetComponent<Button>().colors;
            colors.normalColor = on;
            GetComponent<Button>().colors = colors;
        }
        else{
            TurnOffLight(i);
            var colors = GetComponent<Button>().colors;
            colors.normalColor = off;
            GetComponent<Button>().colors = colors;
        }
    }
    void TurnOnLight(int lightIndex){
        Debug.Log("ripperrooo");
        lights[lightIndex].SetActive(true);
        lightStatus = true;
        levelDiagnostics.power -= powerCost;
    }
    void TurnOffLight(int lightIndex){
        Debug.Log("ripper");
        lights[lightIndex].SetActive(false);
        lightStatus = false;
        levelDiagnostics.power += powerCost;
    }
}
