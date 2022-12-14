using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Bed : MonoBehaviour
{
    public Flowchart chart;
    public GameManager manager;
    public FadeToTransparent fade;
    PlayerRayCast player;
    public LevelDiagnostics levelDiagnostics;
    public bool ate;
    public bool drank;
    public bool objectiveComplete;
    public string wakeUpBlock;
    bool playerInteracting;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerRayCast>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInteracting)
        {
            if(Input.GetButtonDown("Fire1")){
                //eventSystem.GetComponent<StandaloneInputModule>().DeactivateModule();
                player.ReturnMovement();
                playerInteracting = false;
            }
        }
    }

    public void Interact()
    {
        if(objectiveComplete)
        {
            if(ate && drank){
                // do ui shit
                fade.Fade();
                StartCoroutine("Sleep");
                player.InVr();
                // sound shit
            }
            else{
                playerInteracting = true;
                Debug.Log("hungo");
                chart.ExecuteBlock("CantSleep");
                // sound shit
            }
        }
        else{
            playerInteracting = true;
            Debug.Log("got stuff to do");
            chart.ExecuteBlock("ObjectiveNotComplete");
            // sound shit
        }
    }
    public void PlayerInteracting(){
        playerInteracting = true;
    }
    public void ObjectiveComplete(){
        objectiveComplete = true;
    }
    public void ObjectiveNotDone(){
        objectiveComplete = false;
    }
    public void ResetDay(){
        objectiveComplete = false;
        ate = false;
        drank = false;
        manager.ResetDrinkEat();
    }
    public void SetWakeUpBlock(string s){
        wakeUpBlock = s;
    }

    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(5f);
        fade.Fade();
        chart.ExecuteBlock(wakeUpBlock);
    }
}
