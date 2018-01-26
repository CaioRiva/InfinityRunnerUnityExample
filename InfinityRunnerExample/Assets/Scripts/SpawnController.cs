using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField]
    private GameObject obstacle;

    private float spawnRate = 2f;
    private float currentTime;
    private int positionChecker;
    private float yPosition;
	void Start ()
    {
        currentTime = 0f;
	}
	
	void Update ()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= spawnRate)
        {
            currentTime = 0f;
            positionChecker = Random.Range(1, 100);

            if(positionChecker > 50)
            {
                yPosition = -0.03f;      
            }
            else
            {
                yPosition = 0.60f;
            }

            GameObject tempObstacle = Instantiate(obstacle) as GameObject;
            tempObstacle.transform.position = new Vector3(this.transform.position.x, yPosition, 
                tempObstacle.transform.position.z);
        }
	}
}
