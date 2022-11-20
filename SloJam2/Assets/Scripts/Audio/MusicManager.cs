using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioMixerSnapshot bunker;
    public AudioMixerSnapshot vr;
    public float fade;
    public void BunkerMusic()
    {
        bunker.TransitionTo(fade);
    }
    public void VrMusic()
    {
        vr.TransitionTo(fade);
    }
}
