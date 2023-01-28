using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpikeBehaviour : MonoBehaviour
{
   

   public void RestartLevel() {
        SceneManager.LoadScene("MainLevel");
    
    }

}
