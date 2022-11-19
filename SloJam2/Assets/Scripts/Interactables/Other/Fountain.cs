using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
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
                sleepManager.drank = true;
            }
            else{
                // wrong sound
            }
        }
        else{
            //wrong sound
        }
    }
}
