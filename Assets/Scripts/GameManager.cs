using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        Debug.Log("Puntos totales: " + score);
    }
}

