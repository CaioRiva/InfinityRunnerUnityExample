using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementController : MonoBehaviour
{

    private const float speed = -2f;

    private Transform GroundObstacleTransform;
    private float xPosition;

    void Start()
    {
        GroundObstacleTransform = GetComponent<Transform>();
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
    }
}
