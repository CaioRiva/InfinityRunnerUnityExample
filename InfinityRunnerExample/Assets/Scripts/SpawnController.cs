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
    private float positionA = 2.5f;
    private float positionB = 3.75f;

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
                yPosition = positionA;      
            }
            else
            {
                yPosition = positionB;
            }

            GameObject tempObstacle = Instantiate(obstacle) as GameObject;
            tempObstacle.transform.position = new Vector3(this.transform.position.x, yPosition, 
                tempObstacle.transform.position.z);
        }
	}
}
