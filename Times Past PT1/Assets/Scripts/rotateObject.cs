using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour {

    int face = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (face > 3) face = 0;
	}

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 90, 0));
        face++;
    }

    public int getFace()
    {
        return face;
    }
}
