using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightDelay : MonoBehaviour
{
    //varibles for the delay
    public float delay;
    float intensity;
    public float rate;
    public bool ramp;
    public Light2D light;

    // Start is called before the first frame update
    void Awake()
    {
        //set up the target intensity and the current intensity
        intensity = light.intensity;
        light.intensity = 0;


    }

    // Update is called once per frame
    void Update()
    {
        //lower the cooldown
        delay -= Time.deltaTime;

        //if fading in, increase the intensity over time
        if(ramp && delay <=0 && light.intensity < intensity)
        {
            light.intensity += rate*Time.deltaTime;
        }
        //if not, add light once the cooldown is done
        if(!ramp && delay<=0)
        {
            light.intensity = intensity;
        }
    }
}
