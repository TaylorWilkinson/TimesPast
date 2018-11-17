using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCamera : MonoBehaviour {

    public CinemachineVirtualCamera cam;
    public Transform harriet;
    public Transform harrietPivot;
    public Transform basil;
    public Transform basilPivot;
    bool change;


	void Start () {
        cam.Follow = harriet;
        cam.LookAt = harrietPivot;
    }
	

	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)){
            if (change){
                cam.Follow = harriet;
                cam.LookAt = harrietPivot;
            }
            else if (!change) {
                cam.Follow = basil;
                cam.LookAt = basilPivot;
            }

            change = !change;
        }
    }
}
