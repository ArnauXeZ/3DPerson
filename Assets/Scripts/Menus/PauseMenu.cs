using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused;
    public GameObject PauseMenuCanvas;
    private CinemachineVirtualCamera cvCamera;
    public AudioSource musica;
    public Vector3 initialPos = new Vector3(0f, 0f, 0f);
    public static bool Reset;
    public DatosJugador datosJugador; // Referencia al script DatosJugador
    public AudioMixer audioMixer; // Referencia al AudioMixer que controla las opciones de audio

    public GameObject player;
    public GameObject enemigo; // Referencia al enemigo

    void Start()
    {
        PauseMenuCanvas.SetActive(false);
        Paused = false;
        Reset = false;
        Time.timeScale = 1f;
        cvCamera = FindObjectOfType<CinemachineVirtualCamera>();
        CargarOpciones();
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
        // Verificar si el enemigo ha sido destruido
        if (enemigo == null)
        {
            CargarEscenaCreditos();
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

    public void GuardarOpciones()
    {
        // Obtener el valor actual del parámetro "VolumenMusica"
        float volumen;
        audioMixer.GetFloat("VolumenMusica", out volumen);
        PlayerPrefs.SetFloat("Volumen", volumen);

        // Guardar los cambios en las preferencias del jugador
        PlayerPrefs.Save();
    }

    public void CargarOpciones()
    {
        if (PlayerPrefs.HasKey("Volumen"))
        {
            float volumen = PlayerPrefs.GetFloat("Volumen");

            // Establecer el valor del parámetro "VolumenMusica"
            audioMixer.SetFloat("VolumenMusica", volumen);
        }
    }

    public void CargarEscenaCreditos()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}


