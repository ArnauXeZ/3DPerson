using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public AudioSource CoinSound;
   
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            GameManager.instance.AddPoints(1);
            Destroy(gameObject);
            CoinSound.Play();
        }

    }
}
