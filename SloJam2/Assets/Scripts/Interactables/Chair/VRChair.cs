using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class VRChair : MonoBehaviour
{
    PlayerRayCast player;
    public LevelDiagnostics levelDiagnostics;
    public Animator anim;
    public Animator screenAnim;
    public FadeToTransparent fade;
    public CameraManager cameraM;
    public float powerRequirement;
    public float animLength;
    bool playerInteracting;
    public Flowchart chart;
    public GameManager manager;
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
            if(Input.GetButtonDown("Cancel")){
                //eventSystem.GetComponent<StandaloneInputModule>().DeactivateModule();
                player.ReturnMovement();
                playerInteracting = false;
            }
        }
    }
    public void Interact()
    {
        if(levelDiagnostics.power > powerRequirement)
        {
            screenAnim.Play("ScreenToVRWorld");
            levelDiagnostics.power -= powerRequirement;
            // play animation
            anim.SetTrigger("PullIn");
            // reference camera switcher
            StartCoroutine("SwitchCams");
            // do ui shit
            fade.Fade();
            // sound shit
        }
        else{
            playerInteracting = true;
            Debug.Log("not enough power");
            // sound shit
        }
    }

    IEnumerator SwitchCams(){
        yield return new WaitForSeconds(animLength);
        Debug.Log("losdifh");
        cameraM.SwitchToVR();
        manager.PlayConvo();
    }
    public void PlayerInteracting(){
        playerInteracting = true;
    }
    public void ComputerGreet(string s)
    {
        anim.Play("ScreenPullOut");
        chart.ExecuteBlock(s);
    }
}
