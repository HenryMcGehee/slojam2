using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerHighLight : MonoBehaviour
{
    public List<GameObject> zones;
    public Material selectedMat;
    public Material otherMat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMaterials(int selected)
    {
        for (int i = 0; i < zones.Count; i++)
        {
            if(i == selected)
            {
                zones[i].GetComponent<Renderer>().material = selectedMat;
            }
            else{
                zones[i].GetComponent<Renderer>().material = otherMat;
            }
        }
    }
}
