using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLogManager : MonoBehaviour
{
    public List<GameObject> logs;

    public void TurnOnLog(int i)
    {
        logs[i].SetActive(true);
    }
}
