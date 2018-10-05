using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSwitch : MonoBehaviour
{

    GameObject sprout, tree, rocks;
    int pastObject;

    // Use this for initialization
    void Start()
    {
        sprout = GameObject.Find("Sprout");
        tree = GameObject.Find("Tree");
        rocks = GameObject.Find("Rocks");

        pastObject = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //change character when pressing space bar
        if (Input.GetKeyDown("space"))
        {
            //update the status of whether pastObject is active
            if (pastObject == 0)
            {
                pastObject = 1;
            }
            else if (pastObject == 1)
            {
                pastObject = 0;
            }
        }

        if (pastObject == 0)
        {
            //ensure that past objects are not visible or active
            sprout.SetActive(false);
            tree.SetActive(true);
            rocks.SetActive(true);
        }
        else if (pastObject == 1)
        {
            //ensure that past objects are active while present objects aren't visible or active
            sprout.SetActive(true);
            tree.SetActive(false);
            rocks.SetActive(false);
        }
    }
}