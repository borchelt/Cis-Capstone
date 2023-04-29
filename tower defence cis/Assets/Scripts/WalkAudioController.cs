using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WalkAudioController : MonoBehaviour
{
    public AudioSource audio;
    public float strideLength;
    Transform lastLocation;
    Transform currentLoaction;
    float checkTimer = .1f;
    // Start is called before the first frame update
    void Start()
    {
        lastLocation = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(checkTimer<=0)
        {

        }
    }
}
