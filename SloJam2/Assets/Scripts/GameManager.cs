using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GameManager : MonoBehaviour
{
    [Header("Progression")]
    public bool startFromBeginning;
    public CameraManager cameraManager;
    public Flowchart chart;
    public int convoIndex;
    public PlayerRayCast player;
    // vars for chair screen anim
    [Header("Chair Screen Anim")]
    public LevelDiagnostics levelDiagnostics;
    public VRChair chair;
    public NutrientDispenser nutrientDispenser;
    public Fountain fountain;
    public Animator chairScreenAnim;
    public List<ColonyController> controller;
    public List<ColonyOxygenController> oxyController;
    public List<LightController> lightController;
    bool Overriden;
    // Start is called before the first frame update
    void Start()
    {
        if(startFromBeginning)
        {
            player.StartInVRWorld();
            chart.ExecuteBlock("1");
            levelDiagnostics.power = 150;
        }
        
    }
    public void SetPower(float p)
    {
        levelDiagnostics.power = p;
    }
    public void PlayConvo()
    {
        chart.ExecuteBlock(convoIndex.ToString());
    }
    public void setConvoIndex(int i)
    {
        convoIndex = i;
    }

    // Update is called once per frame
    void Update()
    {
        // Screen Update
        if(levelDiagnostics.power >= chair.powerRequirement)
        {
            chairScreenAnim.SetBool("CanUse", true);
        }
        else{
            chairScreenAnim.SetBool("CanUse", false);
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            if(!player.inVR)
            {
                Override();
            }
        }

        // if(Input.GetKeyDown(KeyCode.K))
        // {
        //     Cursor.visible = true;
        //     Cursor.lockState = CursorLockMode.None;
        // }
    }

    public void ResetDrinkEat()
    {
        nutrientDispenser.ration = false;
        fountain.ration = false;
    }

    public void Override()
    {
        if(!Overriden)
        {
            Overriden = true;
            foreach (var item in controller)
            {
                item.locked = false;
            }

            foreach (var item in oxyController)
            {
                item.locked = false;
            }

            foreach (var item in lightController)
            {
                item.locked = false;
            }
            chart.ExecuteBlock("Override");
        }
    }
}
