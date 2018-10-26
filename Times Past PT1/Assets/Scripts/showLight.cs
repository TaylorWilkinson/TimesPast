using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showLight : MonoBehaviour {

    GameObject left, middle, right, leftMirror, middleMirror, rightMirror;
    rotateObject roLeft, roMiddle, roRight;
    bool lit;

    // Use this for initialization
    void Start () {

        left = GameObject.Find("Point Light Left");
        middle = GameObject.Find("Point Light Middle");
        right = GameObject.Find("Point Light Right");

        leftMirror = GameObject.Find("MirrorLeft");
        middleMirror = GameObject.Find("MirrorMiddle");
        rightMirror = GameObject.Find("MirrorRight");

        roLeft = leftMirror.GetComponent<rotateObject>();
        roMiddle = middleMirror.GetComponent<rotateObject>();
        roRight = rightMirror.GetComponent<rotateObject>();

        lit = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (roLeft.getFace() == 0 || roLeft.getFace() == 7 || roLeft.getFace() == 6)
        {
            left.SetActive(true);
         
        } else if (roLeft.getFace() == 3 || roLeft.getFace() == 4 || roLeft.getFace() == 5 || 
            roLeft.getFace() == 2 || roLeft.getFace() == 1)
        {
            left.SetActive(false);
        }

        if (roMiddle.getFace() == 5 || roMiddle.getFace() == 6 || roMiddle.getFace() == 7)
        {
            if (lit == true)
            {
                middle.SetActive(true);
            }
            else if (lit == false)
            {
                middle.SetActive(false);
            }
           
        } else if (roMiddle.getFace() == 0 || roMiddle.getFace() == 1 || roMiddle.getFace() == 2
            || roMiddle.getFace() == 3 || roMiddle.getFace() == 4)
        {
            middle.SetActive(false);
        }

        if (roRight.getFace() == 5 || roRight.getFace() == 6 || roRight.getFace() == 7)
        {
            right.SetActive(true);

            if (roRight.getFace() == 6)
            {
                lit = true;
            } 
            else
            {
                lit = false;
            }
            
        } else if (roRight.getFace() == 0 || roRight.getFace() == 1 || roRight.getFace() == 2
            || roRight.getFace() == 3 || roRight.getFace() == 4)
        {
            right.SetActive(false);
            lit = false;
        }

    }
    
}
