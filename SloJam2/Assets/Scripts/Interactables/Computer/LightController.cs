using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public LevelDiagnostics levelDiagnostics;
    public float powerCost;
    public List<GameObject> lights;
    public bool lightStatus = true;
    public void ToggleLight(int i)
    {
        if(!lightStatus){
            TurnOnLight(i);
        }
        else{
            TurnOffLight(i);
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
