using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            GameManager.instance.AddPoints(1);
            Destroy(gameObject);
           
        }

    }
}
