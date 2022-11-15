using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToTransparent : MonoBehaviour
{
    public Animator anim;
    public void Fade(){
        anim.SetTrigger("Fade");
    }
}
