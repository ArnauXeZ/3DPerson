using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;


public class PauseMenu : MonoBehaviour
{
    public static bool Paused;
    public GameObject PauseMenuCanvas;
    private CinemachineVirtualCamera cvCamera;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenuCanvas.SetActive(false);
        Paused = false;
        Time.timeScale = 1f;
        cvCamera = FindObjectOfType<CinemachineVirtualCamera>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                Play();
            }
            else
            {
                Stop();

            }
        }
    }
    
    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        Paused = true;
        cvCamera.enabled = false;

    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        cvCamera.enabled = true;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
