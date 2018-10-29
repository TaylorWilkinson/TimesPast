using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnClick : MonoBehaviour, IActionOnClick {
    [SerializeField]
    private int totalRotate = 4;
    [SerializeField]
    private int rotateCount = 0;
    [SerializeField]
    private int winningFaceCount = 2;

    [SerializeField]
    private Light mirrorLight;

    [SerializeField]
    private int[] reflectiveValues;

    public void OnObjectClick() {
        //do the rotate logic here
        transform.Rotate(0, 90, 0);
        rotateCount++;
        rotateCount = rotateCount % totalRotate;

        if (rotateCount == winningFaceCount)
        {
            Debug.Log("Correct mirror orientation");
        }

        bool lightOn = false;

        for (int i = 0; i < reflectiveValues.Length; i++)
        {
            if (rotateCount == reflectiveValues[i])
            {
                lightOn = true;
            }
            if (lightOn) {
                mirrorLight.enabled = true;
            } else {
                mirrorLight.enabled = false;
            }
        }
    }
}
