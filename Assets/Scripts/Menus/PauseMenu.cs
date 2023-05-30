using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused;
    public GameObject PauseMenuCanvas;
    private CinemachineVirtualCamera cvCamera;
    public AudioSource musica;
    public Vector3 initialPos = new Vector3(0f, 0f, 0f);
    public static bool Reset;
    public DatosJugador datosJugador; // Referencia al script DatosJugador

    public GameObject player;

    void Start()
    {
        PauseMenuCanvas.SetActive(false);
        Paused = false;
        Reset = false;
        Time.timeScale = 1f;
        cvCamera = FindObjectOfType<CinemachineVirtualCamera>();
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }

        if (Reset)
        {
            ResetPosition();
        }
    }

    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        cvCamera.enabled = false;
        musica.mute = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResetPosition()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        cvCamera.enabled = true;
        musica.mute = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        player.transform.position = initialPos;
        player.transform.rotation = Quaternion.identity;

        // Reiniciar la vida del personaje al 100
        datosJugador.vidaPlayer = 100;

        musica.Stop();
        musica.Play();
    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        cvCamera.enabled = true;
        musica.mute = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}


