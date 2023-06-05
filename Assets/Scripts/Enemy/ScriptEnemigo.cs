using UnityEngine;
using UnityEngine.AI;

public class ScriptEnemigo : MonoBehaviour
{
    public Transform objetivo; // El objetivo que el enemigo perseguirá (por ejemplo, el jugador)
    private NavMeshAgent agente; // El componente NavMeshAgent para la navegación del enemigo
    private Animator animador; // El componente Animator para controlar las animaciones del enemigo

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animador = GetComponent<Animator>();
    }

    void Update()
    {
        // Calcula la distancia entre el enemigo y el objetivo
        float distancia = Vector3.Distance(transform.position, objetivo.position);

        // Si la distancia es mayor que un valor determinado, persigue al objetivo
        if (distancia > 6f)
        {
            agente.SetDestination(objetivo.position);
             animador.SetBool("Caminar", true);
             animador.SetBool("Atacar", false);
        }
        // Si la distancia es menor o igual a un valor determinado, ataca al objetivo
        else
        {
           // agente.SetDestination(transform.position);
            animador.SetBool("Caminar", false);
            animador.SetBool("Atacar", true);
        }
        
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

   // private void OnDrawGizmos()
    //{
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position.normalized, transform.position.normalized * Vector3.Distance(transform.position, objetivo.position));
   // }
}





