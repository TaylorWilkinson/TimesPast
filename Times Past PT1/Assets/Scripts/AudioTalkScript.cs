using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTalkScript : MonoBehaviour
{

    public AudioClip harrietClip;
    public AudioClip basilClip;

    public AudioSource talkSource;

    // Use this for initialization
    void Start()
    {
        talkSource.clip = harrietClip;
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    public void HarrietTalks()
    {
        talkSource.clip = harrietClip;
        talkSource.Play();
    }

    public void BasilTalks()
    {
        talkSource.clip = basilClip;
        talkSource.Play();
    }

}
