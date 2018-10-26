
// Script taken from https://gamedev.stackexchange.com/questions/142435/stopping-a-reflecting-raycast-linerender-laser
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(LineRenderer))]
public class RaycastReflection : MonoBehaviour
{
    //this game object's Transform
    private Transform goTransform;
    //the attached line renderer
    private LineRenderer lineRenderer;
    //a ray
    private Ray ray;
    //a RaycastHit variable, to gather informartion about the ray's collision
    private RaycastHit hit;
    //reflection direction
    private Vector3 direction;
    //the number of reflections
    public int nReflections = 2;
    //max length
    public float maxLength = 100f;
    //the number of points at the line renderer
    private int numPoints;
    //private int pointCount;

    Vector3 temp;
    Vector3 idk;
    int y;
    GameObject mirror;
    rotateObject roMirror;

    void Awake()
    {
        //get the attached Transform component  
        goTransform = this.GetComponent<Transform>();
        //get the attached LineRenderer component  
        lineRenderer = this.GetComponent<LineRenderer>();

        temp = goTransform.position;
        if (this.name == "MirrorMiddle" || this.name == "MirrorRight") { 
        temp.y += 2.75f;
            if (this.name == "MirrorRight")
            {
                y = 215;
            } else if (this.name == "MirrorMiddle") 
            {
                y = 180;
            }
         } else if(this.name == "MirrorLeft")
        {
            temp.y += 0.25f;
            y = -120;
        }

        mirror = GameObject.Find("MirrorMiddle");
        roMirror = mirror.GetComponent<rotateObject>();
    }
    void Update ()
    {
        idk = Quaternion.Euler(0, y, 0) * transform.forward;

        //clamp the number of reflections between 1 and int capacity  
        nReflections = Mathf.Clamp (nReflections, 1, nReflections);
        ray = new Ray (/*goTransform.position*/temp, /*goTransform.forward*/ idk);    
        //start with just the origin
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition (0, /*goTransform.position*/ temp);
        float remainingLength = maxLength;
        //bounce up to n times
        for (int i = 0; i < nReflections; i++) {
            // ray cast
            if (Physics.Raycast (ray.origin, ray.direction, out hit, remainingLength)) {
                //we hit, update line renderer
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition (lineRenderer.positionCount - 1, hit.point);
                // update remaining length and set up ray for next loop
                remainingLength -= Vector3.Distance (ray.origin, hit.point);
                ray = new Ray (hit.point, Vector3.Reflect(ray.direction, hit.normal));
                // break loop if we don't hit a Mirror
                if (hit.collider.tag != "Mirror")
                    break;
                if (roMirror.getFace() != 6) break;
            } else {
                // We didn't hit anything, draw line to end of ramainingLength
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition (lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
                break;
            }
        }
    }
}