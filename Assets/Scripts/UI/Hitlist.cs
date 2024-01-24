using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hitlist : MonoBehaviour
{
    public Canvas canvas;


    private bool canvasOn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)&& canvasOn == false)
        {
            openMenu();
        }

        if (Input.GetKeyUp(KeyCode.Tab)&& canvasOn == true)
        {
            closeMenu();
        }

    }

    void openMenu()
    {
        canvas.gameObject.SetActive(true);
        canvasOn = true;
    }

    void closeMenu()
    {
        canvas.gameObject.SetActive(false);
        canvasOn = false;

    }

}
