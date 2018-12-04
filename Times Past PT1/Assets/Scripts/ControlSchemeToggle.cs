using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSchemeToggle : MonoBehaviour {

    public float FadeRate;
    private Image image;
    private float targetAlpha;
    private float startAlpha;
    public float desiredAlpha;

    bool imageBlank, imageShowing;

    // Use this for initialization
    void Start() {
        this.image = this.GetComponent<Image>();
        if (this.image == null) {
            Debug.LogError("Error: No image on " + this.name);
        }

        this.targetAlpha = this.image.color.a;

        imageBlank = true;
        imageShowing = false;
    }

    // Update is called once per frame
    void Update() {

        //if (imageShowing == true) {
        //    StartCoroutine(FadeOut());
        //}

        Color curColor = this.image.color;
        float alphaDiff = Mathf.Abs(curColor.a - this.targetAlpha);
        if (alphaDiff > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, this.FadeRate * Time.deltaTime);
            this.image.color = curColor;
        }
        if (imageBlank == true) {
            StartCoroutine(FadeIn());
            imageBlank = false;
        }

        if (imageShowing) {
            StartCoroutine(FadeOut());
            imageShowing = false;
        }

        //print(curColor.a);
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(0.5f);
        this.targetAlpha = desiredAlpha;
        imageShowing = true;
    }

    IEnumerator FadeOut() {
        yield return new WaitForSeconds(5f);
        this.targetAlpha = 0.0f;
    }
}
