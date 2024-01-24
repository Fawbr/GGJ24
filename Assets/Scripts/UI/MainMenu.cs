using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("Antonio");
    }

    public void QuitGame()
    {
        print("Quit");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
