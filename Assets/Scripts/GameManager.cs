using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Instancia del GameManager

    public Text scoreText; // Referencia al texto de la puntuaci�n en la interfaz de usuario

    private int score = 0; // Puntuaci�n actual del jugador

    void Awake()
    {
        // Asegurarse de que solo haya una instancia del GameManager en la escena
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Inicializar la puntuaci�n en 0 al comenzar el juego
        score = 0;
        UpdateScoreText();
    }

    public void AddPoints(int points)
    {
        // A�adir los puntos recibidos a la puntuaci�n
        score += points;

        // Actualizar el texto de la puntuaci�n en la interfaz de usuario
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // Actualizar el texto de la puntuaci�n en la interfaz de usuario con el valor actual de la puntuaci�n
        scoreText.text = "Puntuaci�n: " + score.ToString();
    }
}
