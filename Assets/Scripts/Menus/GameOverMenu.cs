using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public DatosJugador datosJugador;
    public AudioSource backgroundMusic;
    public AudioSource OverSound;
    private CinemachineVirtualCamera cvCamera;

    private void Start()
    {
        gameOverCanvas.SetActive(false);
        cvCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }
    
    private bool gameOverDisplayed = false;

    private void Update()
    {
        if (datosJugador.vidaPlayer <= 0 && !gameOverDisplayed)
        {
            ShowGameOverMenu();
            gameOverDisplayed = true;
        }
    }


    public void ShowGameOverMenu()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cvCamera.enabled = false;

        // Detener la reproducción de la música de fondo
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }

        // Reproducir el sonido de Game Over
        if (OverSound != null)
        {
            OverSound.Play();
            Debug.Log("Reproduciendo el sonido de Game Over.");
        }
        else
        {
            Debug.LogWarning("AudioSource de Game Over no asignado.");
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}



