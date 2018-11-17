using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //1. follow on player's X/Z plane
    //2. Smooth rotation around the player in 45 degree increments

    public Transform target;
    public Vector3 offsetPos;
    public float moveSpeed = 5;
    public float turnSpeed = 10;
    public float smoothSpeed = 0.5f;
    public float maxDistance = 5;

    Quaternion targetRotation;
    Vector3 targetPos;
    bool didHitWall = false;

    bool smoothRotating = false; //determine if we're trying to move to new rotation

    void Start()
    {
        var cameraCollider = gameObject.GetComponent<CapsuleCollider>();
        cameraCollider.isTrigger = true;
    }

    void Update()
    {
        MoveWithTarget();
        LookAtTarget();

        if (Input.GetKeyDown(KeyCode.Q) && !smoothRotating)
        {
            //left rotation
            StartCoroutine("RotateAroundTarget", -45);
        }

        if (Input.GetKeyDown(KeyCode.E) && !smoothRotating)
        {
            //right rotation
            StartCoroutine("RotateAroundTarget", 45);
        }

        if ((transform.position - target.position).magnitude > maxDistance)
        {
            didHitWall = false;
        }
    }

    void MoveWithTarget()
    {
        if (!didHitWall)
        {
            targetPos = target.position + offsetPos;
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    void LookAtTarget()
    {
        targetRotation = Quaternion.LookRotation((target.position + new Vector3(0, 3f, 0)) - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    IEnumerator RotateAroundTarget(float angle)
    {
        Vector3 vel = Vector3.zero;
        Vector3 targetOffsetPos = Quaternion.Euler(0, angle, 0) * offsetPos;
        float dist = Vector3.Distance(offsetPos, targetOffsetPos);

        smoothRotating = true;

        while (dist > 10f)
        {
            offsetPos = Vector3.SmoothDamp(offsetPos, targetOffsetPos, ref vel, smoothSpeed);
            dist = Vector3.Distance(offsetPos, targetOffsetPos);

            yield return null;
        }

        smoothRotating = false;
        offsetPos = targetOffsetPos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Wall")
        {
            //Vector3 distanceFromWall = transform.position - other.transform.position;
            //offsetPos.z = -distanceFromWall.z / 3;
            didHitWall = true;
            //Debug.Log("collision detected");
        }
    }
}

