using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Destroy : MonoBehaviour
{
    public AudioSource DestroySound;
    public GameObject floar; // Referencia al enemigo que queremos destruir
    public NavMeshAgent enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            DestroySound.Play();

            // Destruir el enemigo y ajustar su posición al caer al vacío
            Destroy(floar);
            enemy.enabled = false;
        }
    }
}




