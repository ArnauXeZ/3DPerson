using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public int pointsToAdd = 10;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Sumar puntos al marcador del jugador
            GameManager.instance.AddPoints(pointsToAdd);

            // Destruir el objeto recolectable
            Destroy(gameObject);
        }
    }
}

