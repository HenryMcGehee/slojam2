using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutrientDispenser : MonoBehaviour
{
    public Bed sleepManager;
    public Animator anim;
    public bool ration;
    public Transform spawn;
    public GameObject food;
    public void Interact(){
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
        }
    }
}
