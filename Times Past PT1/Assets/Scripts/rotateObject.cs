using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour {

    int face = 0;

    public int degreesOfRotation;
    int faceValue;

	// Use this for initialization
	void Start () {
        faceValue = ((360 / degreesOfRotation) - 1);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("FACE VALUE = " + faceValue);
        //if (face > 3) face = 0;
        if (face > faceValue) face = 0;
    }

    private void OnMouseDown()
    {
        //transform.Rotate(new Vector3(0, 90, 0));
        transform.Rotate(new Vector3(0, degreesOfRotation, 0));
        face++;
    }

    public int getFace()
    {
        return face;
    }
}
