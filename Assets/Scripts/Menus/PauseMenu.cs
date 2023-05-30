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
    private AudioSource Musica;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenuCanvas.SetActive(false);
        Paused = false;
        Time.timeScale = 1f;
        cvCamera = FindObjectOfType<CinemachineVirtualCamera>();
        Musica = FindObjectOfType<AudioSource>();
        Cursor.visible = false; // Oculta el cursor del mouse
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla

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
        Musica.mute = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        cvCamera.enabled = true;
        Musica.mute = false;
        Cursor.visible = false; // Oculta el cursor del mouse
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
