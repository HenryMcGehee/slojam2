using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerCamMove : MonoBehaviour
{
    public Transform camLoc;
    public Transform camLookAt;
    void Update()
    {
        LookAt(camLookAt.position);
        transform.position = Vector3.Lerp(transform.position, camLoc.position, 2 * Time.deltaTime);
    }

    void LookAt(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
