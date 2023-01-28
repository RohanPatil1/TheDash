using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class PingPongLight : MonoBehaviour
{
    private Light2D myLight;

    void Start()
    {
        myLight = GetComponent<Light2D>();
    }

    void Update()
    {
        myLight.intensity = Mathf.PingPong(Time.time * 2, 7);
       // Debug.Log("PING PONG: "+ myLight.intensity);
    }
}