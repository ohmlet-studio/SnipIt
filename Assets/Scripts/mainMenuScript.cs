using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void playGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Museum");
    }

    public void quit()
    {
        Application.Quit();
    }
}
