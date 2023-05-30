using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    public GameObject Player;
    public AudioSource DamageSound;

    private void OnTriggerEnter(Collider other)
    {
        Player.GetComponent<DatosJugador>().vidaPlayer -= damage;
        DamageSound.Play();
    }
}
