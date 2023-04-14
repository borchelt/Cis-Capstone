using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightDelay : MonoBehaviour
{
    public float delay;
    float intensity;
    public float rate;
    public bool ramp;
    public Light2D light;
    // Start is called before the first frame update
    void Awake()
    {
        intensity = light.intensity;
        light.intensity = 0;


    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;

        if(ramp && delay <=0 && light.intensity < intensity)
        {
            light.intensity += rate*Time.deltaTime;
        }
        if(!ramp && delay<=0)
        {
            light.intensity = intensity;
        }
    }
}
