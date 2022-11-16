using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdatePowerUI : MonoBehaviour
{
    public LevelDiagnostics levelDiagnostics;
    public Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = levelDiagnostics.power.ToString();
    }
}
