using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutoSelect : MonoBehaviour
{
    EventSystem eventSystem;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){

            eventSystem.SetSelectedGameObject(button);
        }
    }
}
