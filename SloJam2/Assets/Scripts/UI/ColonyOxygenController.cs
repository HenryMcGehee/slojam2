using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColonyOxygenController : MonoBehaviour
{
    public LevelDiagnostics levelDiagnostics;
    public float powerCost;
    public bool lightStatus = true;
    public Color on;
    public Color off;
    public Text text;
    public ParticleSystem particle;
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
        lightStatus = true;
        levelDiagnostics.power -= powerCost;
        particle.Play();

        var colors = GetComponent<Button>().colors;
        colors.normalColor = on;
        GetComponent<Button>().colors = colors;
        text.text = "Turn Off";
    }
    void TurnOffLight(){
        Debug.Log("oxygen off");
        lightStatus = false;
        levelDiagnostics.power += powerCost;
        particle.Stop();
        var colors = GetComponent<Button>().colors;
        colors.normalColor = off;
        GetComponent<Button>().colors = colors;
        text.text = "Turn On";
    }
    IEnumerator Die(){
        yield return new WaitForSeconds(10);
    }
}
