using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUtils : MonoBehaviour
{
    private float fallMultiplier = 3.5f;
    private float lowJumpMultiplier = 3f;

    private Rigidbody2D _rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rigidBody2D.velocity.y < 0)
        {
            _rigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rigidBody2D.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }
}
