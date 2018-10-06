using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour {

    public string objectName;
    public string objectNameInOtherTime;

    GameObject otherObject;

	// Use this for initialization
	void Start () {

        otherObject = GameObject.Find(objectNameInOtherTime);

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            //turn screenpoint into ray, from the camera into mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    //PrintName(hit.transform.gameObject);

                    /*
                    BoxCollider bc = hit.collider as BoxCollider;
                    if (bc != null) {
                        Destroy(bc.gameObject);
                    }

                    CapsuleCollider cc = hit.collider as CapsuleCollider;
                    if (cc != null) {
                        Destroy(cc.gameObject);
                    }
                    */


                    CapsuleCollider cc;
                    if (cc = hit.transform.GetComponent<CapsuleCollider>()){
                        transform.position = new Vector3(41, -6, 28);
                        DestroyOtherObject(gameObject);
                    }
                }

            }
        }
	}

    private void DestroyOtherObject(GameObject go) {
        if (objectNameInOtherTime != "") {
            //Destroy(otherObject.gameObject);
            otherObject.transform.position = new Vector3(41, -6, 28);
        }
    }

    private void PrintName(GameObject go) {
        print(go.name);
    }
}
