using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraMovement : MonoBehaviour
{
    public GameObject playerObj;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private AudioSource bgMusic;


    

    // Start is called before the first frame update
    void Start()
    {
        bgMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!playerObj.activeSelf) {
            StartCoroutine(RestartAfterExplode());
            bgMusic.Stop();
          
        }
    }

    void LateUpdate()
    {
        float x = Mathf.Clamp(playerObj.transform.position.x, minX, maxX);
        float y = Mathf.Clamp(playerObj.transform.position.y, minY, maxY);

        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);

    }
    private IEnumerator RestartAfterExplode()
    {

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("MainLevel");

    }


}
