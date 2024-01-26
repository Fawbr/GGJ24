using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Camera bloodclasscamera;
    public Camera cleanclasscamera;
    float time;
    [SerializeField] bool blood = false;

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 3f)
        {
            blood = !blood;
            if (blood)
            {
                Debug.Log("aaa");
                showBloodCam();
            }
            if (!blood)
            {
                Debug.Log("bbb");
                showCleanCam();
            }
            time = 0f;
        }
    }

    public void showBloodCam()
    {
        cleanclasscamera.enabled = false;
        bloodclasscamera.enabled = true;
    }

    public void showCleanCam()
    {
        bloodclasscamera.enabled = false;
        cleanclasscamera.enabled = true;
    }

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
