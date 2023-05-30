using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosJugador : MonoBehaviour
{
    public int vidaPlayer;
    public Slider vidaVisual;
    

    private void Update()
    {
        vidaVisual.value = vidaPlayer;
        // Verificar si el jugador ha ca�do por debajo de la posici�n Y -40
        if (transform.position.y < -40f)
        {
            vidaPlayer = 0;
        }
    }
}
