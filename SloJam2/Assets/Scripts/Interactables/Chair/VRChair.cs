using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRChair : MonoBehaviour
{
    public Animator anim;
    public CameraManager cameraM;
    public float animLength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact()
    {
        // play animation
        anim.SetTrigger("PullIn");
        // reference camera switcher
        StartCoroutine("SwitchCams");
        // do ui shit
        // sound shit
    }

    IEnumerator SwitchCams(){
        yield return new WaitForSeconds(animLength);
        Debug.Log("losdifh");
        cameraM.SwitchToVR();
    }
}
