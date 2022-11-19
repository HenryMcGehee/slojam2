using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform target;
    public Transform camLoc;
    public float ease;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAt(target.position);
        transform.position = Vector3.Lerp(transform.position, camLoc.position, ease * Time.deltaTime);
    }
    public void ChangeTarget(Transform t){
        target = t;
    }
    public void ChangePos(Transform t){
        camLoc = t;
    }
    void LookAt(Vector3 t)
    {
        Vector3 direction = (t - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
