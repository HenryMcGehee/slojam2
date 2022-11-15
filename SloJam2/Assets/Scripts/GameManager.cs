using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GameManager : MonoBehaviour
{
    [Header("Progression")]
    public bool startFromBeginning;
    public CameraManager cameraManager;
    public Flowchart gfChart;
    public PlayerRayCast player;
    // vars for chair screen anim
    [Header("Chair Screen Anim")]
    public LevelDiagnostics levelDiagnostics;
    public VRChair chair;
    public Animator chairScreenAnim;
    // Start is called before the first frame update
    void Start()
    {
        if(startFromBeginning)
        {
            player.StartInVRWorld();
            gfChart.ExecuteBlock("Conversation 1");
        }
        
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


        // if(Input.GetKeyDown(KeyCode.K))
        // {
        //     Cursor.visible = true;
        //     Cursor.lockState = CursorLockMode.None;
        // }
    }

}
