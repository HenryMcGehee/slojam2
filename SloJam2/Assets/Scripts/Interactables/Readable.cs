using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Readable : MonoBehaviour
{
    
    public Sprite s;
    public string t;
    ReadableUI readable;
    // Start is called before the first frame update
    void Start()
    {
        readable = GameObject.FindGameObjectWithTag("Readable").GetComponent<ReadableUI>();
    }
    void Update()
    {
        if(readable.page.activeSelf == true)
        {
            if(Input.GetButtonDown("Fire1")){
                readable.ClosePage();
            }
        }
    }

    public void Interact()
    {
        readable.ShowPage(s, t, transform);
    }
}
