using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementController : MonoBehaviour
{

    private const float speed = -2.15f;

    private Transform GroundObstacleTransform;
    private GameObject player;

    private float xPosition;
    private bool scored;

    void Start()
    {
        GroundObstacleTransform = GetComponent<Transform>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        moveObstacle();
    }

    private void moveObstacle()
    {
        xPosition = GroundObstacleTransform.position.x;
        xPosition += speed * Time.deltaTime;

        GroundObstacleTransform.position = new Vector3(xPosition, GroundObstacleTransform.position.y,
            GroundObstacleTransform.position.z);

        if(xPosition <= -7)
        {
            Destroy(this.gameObject);
        }

        if(xPosition < player.transform.position.x && scored == false)
        {
            scored = true;
            PlayerController.score++;
        }
    }
}
