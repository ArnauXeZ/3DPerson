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
    }
}
