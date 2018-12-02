using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    public AudioClip soundClip;
    public AudioClip altSoundClip;

    public AudioSource soundSource;

	// Use this for initialization
	void Start () {
        soundSource.clip = soundClip;
    }
	
	// Update is called once per frame
	void Update () {
	    //check if hitting key
        /*
        if(Input.GetKeyDown(KeyCode.L)) {
            soundSource.Play();
        }
        */
	}

    public void PlaySound() {
        soundSource.clip = soundClip;
        soundSource.Play();
    }

    public void PlayAlternateSound()
    {
        soundSource.clip = altSoundClip;
        soundSource.Play();
    }
}
