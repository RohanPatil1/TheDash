using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{



    public void startGame() {
        SceneManager.LoadScene("MainLevel");   
    }

    public void quitGame() {
        Application.Quit();
    }

    public void goMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
 
}
