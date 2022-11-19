using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective1 : MonoBehaviour
{
    public int lightsOn;
    public Bed sleep;
    public VRChair vr;
    // Start is called before the first frame update
    public void CheckObjective(){
        lightsOn++;
        
        if(lightsOn >= 3)
        {
            sleep.ObjectiveComplete();
            //vr.ObjectiveComplete();
        }
    }
}
