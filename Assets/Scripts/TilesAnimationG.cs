using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesAnimationG : MonoBehaviour
{
    
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        

    }


    public void changeTileAnimator(bool value) {
        animator.SetBool("tileChange", value);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
