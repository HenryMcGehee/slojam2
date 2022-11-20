using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NutrientDispenser : MonoBehaviour
{
    public Bed sleepManager;
    public Flowchart chart;
    public Animator anim;
    public bool ration;
    public bool on;
    public Transform spawn;
    public GameObject food;
    public void Interact(){
        if(on)
        {
            // play sound 
            if(!ration)
            {
                // spawn
                Instantiate(food, spawn.position, Quaternion.identity, spawn);
                anim.SetTrigger("Eat");
                ration = true;
            }
            else{
                // wrong sound
                chart.ExecuteBlock("Eat");
            }
        }
        else{
            // wrong sound
        }
    }
}
