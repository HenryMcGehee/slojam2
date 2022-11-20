using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Fountain : MonoBehaviour
{
    public Flowchart chart;
    public ParticleSystem p;
    public Bed sleepManager;
    public bool ration;
    public bool on;
    public void Interact(){
        if(on)
        {
            if(!ration)
            {
                // play sound
                ration = true;
                p.Play();
                sleepManager.drank = true;
            }
            else{
                // wrong sound
                chart.ExecuteBlock("Drink");
            }
        }
        else{
            //wrong sound
        }
    }
}
