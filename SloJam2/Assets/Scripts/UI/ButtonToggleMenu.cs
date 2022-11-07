using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonToggleMenu : MonoBehaviour
{
    EventSystem eventSystem;
    public GameObject parentMenu;
    public GameObject obj;
    public GameObject defaultSelected;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
    }

    public void ChangeMenu()
    {
        parentMenu.SetActive(false);
        obj.SetActive(true);
        eventSystem.SetSelectedGameObject(defaultSelected);
    }
}
