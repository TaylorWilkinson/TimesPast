using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showLight : MonoBehaviour {

    GameObject right1, right2, right3, right4, left1, left2, left3, left4, leftMirror, rightMirror;
    rotateObject roRight, roLeft;

    // Use this for initialization
    void Start () {

        right1 = GameObject.Find("Cylinder right1");
        right2 = GameObject.Find("Cylinder right2");
        right3 = GameObject.Find("Cylinder right3");
        right4 = GameObject.Find("Cylinder right4");

        left1 = GameObject.Find("Cylinder left1");
        left2 = GameObject.Find("Cylinder left2");
        left3 = GameObject.Find("Cylinder left3");
        left4 = GameObject.Find("Cylinder left4");

        leftMirror = GameObject.Find("MirrorLeft");
        rightMirror = GameObject.Find("MirrorRight");

        roRight = rightMirror.GetComponent<rotateObject>();
        roLeft = leftMirror.GetComponent<rotateObject>();

        //right3.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
        if (roRight.getFace() == 0)
        {
            right1.SetActive(false);
            right2.SetActive(false);
            right3.SetActive(true);
            right4.SetActive(false);

        } else if(roRight.getFace() == 1)
        {
            right1.SetActive(false);
            right2.SetActive(false);
            right3.SetActive(false);
            right4.SetActive(true);

        } else if (roRight.getFace() == 2)
        {
            right1.SetActive(true);
            right2.SetActive(false);
            right3.SetActive(false);
            right4.SetActive(false);

        } else if (roRight.getFace() == 3)
        {
            right1.SetActive(false);
            right2.SetActive(true);
            right3.SetActive(false);
            right4.SetActive(false);

        }

        if (roLeft.getFace() == 0)
        {
            left1.SetActive(false);
            left2.SetActive(false);
            left3.SetActive(true);
            left4.SetActive(false);

        }
        else if (roLeft.getFace() == 1)
        {
            left1.SetActive(false);
            left2.SetActive(false);
            left3.SetActive(false);
            left4.SetActive(true);

        }
        else if (roLeft.getFace() == 2)
        {
            left1.SetActive(true);
            left2.SetActive(false);
            left3.SetActive(false);
            left4.SetActive(false);

        }
        else if (roLeft.getFace() == 3)
        {
            left1.SetActive(false);
            left2.SetActive(true);
            left3.SetActive(false);
            left4.SetActive(false);

        }


    }

    
}
