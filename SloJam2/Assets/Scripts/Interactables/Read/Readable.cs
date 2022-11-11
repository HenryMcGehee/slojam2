using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Readable : MonoBehaviour
{
    
    public Sprite s;
    [TextArea(10,20)]
    public string t1;
    [TextArea(10,20)]
    public string t2;
    [TextArea(10,20)]
    public string t3;
    [TextArea(10,20)]
    public string t4;
    [TextArea(10,20)]
    public string t5;
    public List<string> pages;
    public List<string> pages2;
    int pageIndex;
    ReadableUI readable;
    // Start is called before the first frame update
    void Start()
    {
        readable = GameObject.FindGameObjectWithTag("Readable").GetComponent<ReadableUI>();
        
        pages.Add(t1);
        pages.Add(t2);
        pages.Add(t3);
        pages.Add(t4);
        pages.Add(t5);
        
        for (int i = 0; i < pages.Count; i++)
        {
            if(pages[i] != "")
            {
                pages2.Add(pages[i]);
            }
        }
    }
    void Update()
    {
        if(readable.page.activeSelf == true)
        {
            if(Input.GetButtonDown("Fire1")){
                
                pageIndex++;
                if(pageIndex < pages2.Count)
                    Interact();
                else{
                    readable.ClosePage();
                    pageIndex = 0;
                }
            }
        }
    }

    public void Interact()
    {
        readable.ShowPage(s, pages2[pageIndex], transform);
    }
}
