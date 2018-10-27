using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour {
    public int degreesOfRotation;
    int faceValue;

    int face;

    GameObject left, middle, right;

    // Use this for initialization
    void Start()
    {
        degreesOfRotation = 90;
        faceValue = 3;

        left = GameObject.Find("Point Light Left");
        middle = GameObject.Find("Point Light Middle");
        right = GameObject.Find("Point Light Right");

        face = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //if (face > 7) face = 0;

        faceValue = ((360 / degreesOfRotation) - 1);

        if (face > faceValue) face = 0;
    }

    private void OnMouseDown()
    {
        //transform.Rotate(new Vector3(0, 45, 0));
        //face++;

        //transform.Rotate(new Vector3(0, degreesOfRotation, 0));
        //face++;

        if (this.name == "MirrorLeft")
        {
            left.transform.Rotate(new Vector3(0, degreesOfRotation, 0));
        }
        else if (this.name == "MirrorMiddle")
        {
            middle.transform.Rotate(new Vector3(0, degreesOfRotation, 0));
        }
        else if (this.name == "MirrorRight")
        {
            right.transform.Rotate(new Vector3(0, degreesOfRotation, 0));
        }
    }

    public int getFace()
    {
        return face;
    }

    /*
    int face = 0;

    public int degreesOfRotation;
    int faceValue;

	// Use this for initialization
	void Start () {
        degreesOfRotation = 90;
        faceValue = 3;
	}
	
	// Update is called once per frame
	void Update () {
        //if (face > 3) face = 0;

        //Debug.Log("FACE VALUE = " + faceValue);
        faceValue = ((360 / degreesOfRotation) - 1);

        if (face > faceValue) face = 0;
    }

    private void OnMouseDown()
    {
        //transform.Rotate(new Vector3(0, 90, 0));
        transform.Rotate(new Vector3(0, degreesOfRotation, 0));
        face++;

        if (this.name == "MirrorLeft")
        {
            left.transform.Rotate(new Vector3(0, -45, 0));
        }
        else if (this.name == "MirrorMiddle")
        {
            middle.transform.Rotate(new Vector3(0, -45, 0));
        }
        else if (this.name == "MirrorRight")
        {
            right.transform.Rotate(new Vector3(0, -45, 0));
        }
    }

    public int getFace()
    {
        return face;
    }
    */
}
