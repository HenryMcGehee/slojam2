using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // vars for chair screen anim
    [Header("Chair Screen Anim")]
    public LevelDiagnostics levelDiagnostics;
    public VRChair chair;
    public Animator chairScreenAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Screen Update
        if(levelDiagnostics.power > chair.powerRequirement)
        {
            chairScreenAnim.SetBool("CanUse", true);
        }
        else{
            chairScreenAnim.SetBool("CanUse", false);
        }
    }
}
