using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumePause : MonoBehaviour
{
    public bool resume = false;
    public GameObject pause;
    public GameObject crosshairs;

    public void Awake()
    {
        resume = false;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            resume = true;
        }

        if (resume)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            crosshairs.SetActive(false);
            pause.SetActive(true);
        }
    }

    public void Resume()
    {
        resume = false;
        Time.timeScale = 1;
        Cursor.lockState= CursorLockMode.Locked;
        crosshairs.SetActive(true);
        pause.SetActive(false);
    }
}
