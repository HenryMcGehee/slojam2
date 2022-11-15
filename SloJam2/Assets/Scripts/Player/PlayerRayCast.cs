using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerRayCast : MonoBehaviour
{
    public FPSController playerMove;
    public bool talking;
    public bool canMove;
    public float distanceToSee;
    public Vector3 target;
    public GameObject targetObj;
    RaycastHit whatIHit;
    public GameObject useReticle;
    public Transform defaultPos;
    public Vector3 TargetPos;
    public float inspectSpeed;
    public GameObject vrChair;

    void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
    }

    void Update()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        if(whatIHit.transform != null){
            useReticle.transform.DOScale(new Vector3(0,0,0), .4f);
        }

        if (!talking)
        {
            if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee, layerMask, QueryTriggerInteraction.Ignore))
            {
                if (whatIHit.transform.gameObject.layer == LayerMask.NameToLayer("Interactable") || whatIHit.transform.gameObject.layer == LayerMask.NameToLayer("NPC"))
                {
                    Debug.Log("its interactable");
                    useReticle.transform.DOScale(new Vector3(1,1,1), .2f);
                }
            }

            if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee, layerMask, QueryTriggerInteraction.Ignore))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    if (whatIHit.transform.gameObject.layer == LayerMask.NameToLayer("NPC"))
                    {
                        targetObj = whatIHit.transform.gameObject;
                        //target = whatIHit.transform.position;
                        targetObj.SendMessage("Interact");
                        SetTalking();
                        TargetPos = new Vector3(targetObj.transform.GetChild(1).position.x, targetObj.transform.GetChild(1).position.y, targetObj.transform.GetChild(1).position.z);
                        transform.position = TargetPos;
                        playerMove.canMove = false;
                    }
                    else if (whatIHit.transform.gameObject.layer == LayerMask.NameToLayer("Interactable"))
                    {
                        whatIHit.transform.SendMessage("Interact");
                    }
                }
            }
        }

        if (talking && targetObj != null)
        {
            Talk();
            if(target != new Vector3(0,0,0)){
                LookAt(target);
                // Vector3.Lerp(defaultPos.position, TargetPos, inspectSpeed * Time.deltaTime);
            }
        }
        else{
            transform.position = defaultPos.position;
        }
    }

    public void StartInVRWorld(){
        StartCoroutine("delaySpawn");
    }

    void LookAt(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void Talk()
    {
        target = new Vector3(targetObj.transform.GetChild(0).position.x, targetObj.transform.GetChild(0).position.y, targetObj.transform.GetChild(0).position.z);
        //playerMove.canMove = false;
        //talking = true;
    }
    public void Talk(Transform pos)
    {
        targetObj = pos.gameObject;
        playerMove.canMove = false;
        talking = true;
    }
    public void ChangeTarget(Transform pos)
    {
        targetObj = pos.gameObject;
    }

    public void ReturnMovement()
    {
        targetObj = null;
        target = new Vector3(0,0,0);
        canMove = true;
        playerMove.canMove = true;
        StartCoroutine("delayTalkReset");
    }
    void SetTalking(){
        talking = true;
    }

    IEnumerator delayTalkReset(){
        yield return new WaitForSeconds(0.5f);
        talking = false;
    }

    IEnumerator delaySpawn(){
        yield return new WaitForSeconds(.5f);
        targetObj = vrChair;
        // targetObj.SendMessage("Interact");
        SetTalking();
        TargetPos = new Vector3(targetObj.transform.GetChild(1).position.x, targetObj.transform.GetChild(1).position.y, targetObj.transform.GetChild(1).position.z);
        transform.position = TargetPos;
        playerMove.canMove = false;
    }
}