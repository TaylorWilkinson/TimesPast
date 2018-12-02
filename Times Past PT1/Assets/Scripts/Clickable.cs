using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clickable : MonoBehaviour {
    public event Action<GameObject> OnObjectClick;

    private void OnMouseDown()
    {
        //OnObjectCLick(gameObject);
        GetComponent<IActionOnClick>().OnObjectClick();
    }
}
