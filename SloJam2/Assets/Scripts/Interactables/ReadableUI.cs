using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReadableUI : MonoBehaviour
{
    PlayerRayCast player;
    public GameObject page;
    public Text text;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerRayCast>();
    }
    public void ShowPage(Sprite i, string t, Transform look)
    {
        // Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.None;
        player.Talk(look);
        page.SetActive(true);
        text.text = t;
        page.GetComponent<Image>().sprite = i;
    }
    public void ClosePage()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.ReturnMovement();
        page.GetComponent<Image>().sprite = null;
        text.text = null;
        page.SetActive(false);
    }
}
