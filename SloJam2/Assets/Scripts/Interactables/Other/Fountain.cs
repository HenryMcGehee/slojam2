using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    public Bed sleepManager;
    public void Interact(){
        // play sound 
        sleepManager.drank = true;
    }
}
