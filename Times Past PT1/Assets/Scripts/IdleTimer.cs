using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTimer : MonoBehaviour {
    GameObject harriet, basil;

    Vector3 hMovement, bMovement;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Use this for initialization
    void Start () {
        harriet = GameObject.Find("Harriet");
        basil = GameObject.Find("Basil");

        hMovement = harriet.GetComponent<MovementClass>().movement;
        bMovement = basil.GetComponent<MovementClass>().movement;
    }
	
	// Update is called once per frame
	void Update () {
        while (hMovement == new Vector3(0, 0, 0)) {
            Debug.Log("Harriet Not Moving");
        }

        while (bMovement == new Vector3(0, 0, 0)) {
            Debug.Log("Basil Not Moving");

        }
	}
}
