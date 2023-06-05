using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public AudioSource DestroySound;
    public GameObject floar; // Referencia al enemigo que queremos destruir

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            DestroySound.Play();

            // Destruir el enemigo y ajustar su posici�n al caer al vac�o
            Destroy(floar);
            Destroy(gameObject);
        }
    }
}




