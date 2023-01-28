using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerExplode : MonoBehaviour
{
    public ParticleSystem explosion;



    public void Explode(Vector3 position)
    {
        Instantiate(explosion, position, Quaternion.identity);
    }
}

