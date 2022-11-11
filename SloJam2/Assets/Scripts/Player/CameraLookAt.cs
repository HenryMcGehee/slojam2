using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAt(target.position);
    }
    void LookAt(Vector3 t)
    {
        Vector3 direction = (t - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
