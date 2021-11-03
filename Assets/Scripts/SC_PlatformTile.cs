using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlatformTile : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public Transform leftclamp;
    public Transform Rightclamp;
    public GameObject[] obstacles; //Objects that contains different obstacle types which will be randomly activated
    public GameObject journal;

    public void ActivateRandomObstacle()
    {
        DeactivateAllObstacles();

        System.Random random = new System.Random();
        int randomNumber = random.Next(0, obstacles.Length);
        obstacles[randomNumber].SetActive(true);
    }

    public void DeactivateAllObstacles()
    {
        journal.SetActive(false);
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
        }
    }

    public void activatejournal()
    {
        DeactivateAllObstacles();
        journal.SetActive(true);
    }
}
