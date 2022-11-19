using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodController : MonoBehaviour
{
    public LevelDiagnostics levelDiagnostics;
    public float powerCost;
    public SpriteRenderer oxygenIndicator;
    public NutrientDispenser nutrientDispenser;
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
        oxygenIndicator.color = Color.green;
        nutrientDispenser.on = true;
        lightStatus = true;
        levelDiagnostics.power -= powerCost;

        var colors = GetComponent<Button>().colors;
        colors.normalColor = on;
        GetComponent<Button>().colors = colors;
        text.text = "Turn Off";
    }
    void TurnOffLight(){
        Debug.Log("oxygen off");
        oxygenIndicator.color = Color.red;
        nutrientDispenser.on = false;
        lightStatus = false;
        levelDiagnostics.power += powerCost;

        var colors = GetComponent<Button>().colors;
        colors.normalColor = off;
        GetComponent<Button>().colors = colors;
        text.text = "Turn On";
    }
}
