using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ComputerController : MonoBehaviour
{
    PlayerRayCast player;
    EventSystem eventSystem;
    public GameObject defaultButton;
    bool playerInteracting;
    void OnEnable(){
        eventSystem = EventSystem.current;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerRayCast>();
    }
    public void Interact()
    {
        eventSystem.GetComponent<StandaloneInputModule>().ActivateModule();
        Debug.Log("computer Time");
        eventSystem.SetSelectedGameObject(defaultButton);
        playerInteracting = true;
    }
    void Update(){
        if(playerInteracting)
        {
            if(eventSystem.currentSelectedGameObject != null)
            {
                defaultButton = eventSystem.currentSelectedGameObject;
            }
            
            if (Input.GetMouseButtonDown(0))
                eventSystem.SetSelectedGameObject(defaultButton);

            if(Input.GetButtonDown("Cancel")){
                eventSystem.GetComponent<StandaloneInputModule>().DeactivateModule();
                player.ReturnMovement();
                playerInteracting = false;
            }
        }
    }

    public void Debuger()
    {
        Debug.Log("button hit");
    }
}
