using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public AudioSource DestroySound;
    public GameObject enemy; // Referencia al enemigo que queremos destruir

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            DestroySound.Play();

            // Destruir el enemigo y ajustar su posición al caer al vacío
            Destroy(enemy);
            enemy.transform.position = new Vector3(enemy.transform.position.x, -100f, enemy.transform.position.z);
        }
    }
}




