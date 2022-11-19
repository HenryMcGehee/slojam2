using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDelayDisable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TurnOff");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }
}
