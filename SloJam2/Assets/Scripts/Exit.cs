using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("Fuck");
    }
    IEnumerator Fuck()
    {
        yield return new WaitForSeconds(15f);
        Application.Quit();
        Debug.Log("Quit");

    }
}
