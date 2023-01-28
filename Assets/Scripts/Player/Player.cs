using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal; //2019 VERSIONS
public class Player : MonoBehaviour
{



    private Touch theTouch;
    private float timeTouchEnded;

    [SerializeField]
    private ParticleSystem explosion;

    private Rigidbody2D _rigidBody2D;

    public float Speed = 8.2f;
    private float JumpForce = 655f;
    private SpriteRenderer _spriteRenderer;
    public bool isGrounded;
    private float horizontalInput;
    public bool autoRunOn = false;
    private bool isOnJumper = false;
 

    [SerializeField]
    private GameObject tilesGameObject;

    private Animator tilesAnimator;
    // Start is called before the first frame update
    void Start()
    {

        tilesAnimator = tilesGameObject.GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();

           _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
       
        

        

        Movement();
        if (autoRunOn) {
             transform.Translate(Speed* Time.deltaTime,0,0);
         
            
           // Debug.Log("Player " +  transform.position.x);
        }


        // transform.Translate(Speed* Time.deltaTime,0,0);

    }


    void Movement() {

        if (!autoRunOn) {
            horizontalInput = Input.GetAxis("Horizontal");
            _rigidBody2D.velocity = new Vector2(horizontalInput * Speed, _rigidBody2D.velocity.y);
            
             
        }


        jump();
        
    }


    void jump()
    {



        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (Input.GetTouch(0).phase == TouchPhase.Began && isGrounded && !isOnJumper)
            {
                _rigidBody2D.AddForce(Vector2.up * JumpForce);

                isGrounded = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isOnJumper)
        {

            
            _rigidBody2D.AddForce(Vector2.up * JumpForce);

            isGrounded = false;
            //Debug.Log("Player jumped " + isGrounded);

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player has collided with " + collision.collider.name);
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            isOnJumper = false;
           // Debug.Log("Player jumped " + isGrounded);
        }

        if (collision.gameObject.tag == "Obstacle") {
         
            RestartLevel();
        }

        if (collision.gameObject.tag == "Jumper")
        {
            _rigidBody2D.AddForce(Vector2.up * JumpForce*1.2f);
            isOnJumper = true;
        }

        if (collision.gameObject.tag == "SuperJump")
        {
            _rigidBody2D.AddForce(Vector2.up * JumpForce * 4.2f);
        }

        if (collision.gameObject.tag == "Speeder")

       {
            Speed = 8.5f;
            Destroy(collision.gameObject);
            Debug.Log("Speed is Now 9f");
        }

        if (collision.gameObject.tag == "SpeedBreaker")
        {
            Speed = 8.2f;
            Destroy(collision.gameObject);
            Debug.Log("Speed is Now 8f");
        }
        if (collision.gameObject.tag == "EndLevel")
        {


            SceneManager.LoadScene("MainMenu");
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TilesChanger")
        {
            tilesAnimator.SetBool("tileChange", true);

            Debug.Log("Tile Animation Type has been Changed");
        }

        if (collision.gameObject.tag == "TilesReverted")
        {
            tilesAnimator.SetBool("tileChange", false);

            Debug.Log("Tile Animation Type has been Changed");
        }

    }

    public void RestartLevel()
    {
       
        gameObject.SetActive(false);

        Explode(transform.position);
        

        


        

       



    }
    public void Explode(Vector3 position)
    {
        Instantiate(explosion, position, Quaternion.identity);
    }

  


}
