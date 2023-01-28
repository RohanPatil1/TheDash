using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class PlayerLight : MonoBehaviour
{
    [SerializeField]
    public GameObject playerObj;


    // Update is called once per frame
    void Update()
    {
        //transform.Translate(8.0f * Time.deltaTime, 0, 0);
        transform.SetParent(playerObj.transform);



    }


}
