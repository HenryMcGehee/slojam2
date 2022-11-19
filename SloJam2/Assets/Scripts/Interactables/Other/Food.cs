using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Bed sleepManager;
    void Start()
    {
        sleepManager = GameObject.FindGameObjectWithTag("SleepManager").GetComponent<Bed>();
    }
    public void Interact(){
        // play sound 
        sleepManager.ate = true;
        Destroy(gameObject);
    }
}
