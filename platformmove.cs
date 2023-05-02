using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmove : MonoBehaviour
{
    public Transform[] platformPosition = new Transform[3];
    int direction = 1;
    public float speed;
    Vector2 target;


    // Update is called once per frame
    void Update()
    {
        target = currentMovementTarget();


        float distance = (target - (Vector2)platformPosition[0].position).magnitude;

        if (distance <= .5f)
        {
            direction *= -1;
        }
    }

    private void FixedUpdate()
    {
        platformPosition[0].position = Vector2.Lerp(platformPosition[0].position, target, speed * Time.deltaTime);
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return platformPosition[1].position;
        }
        else
        {
            return platformPosition[2].position;
        }
    }
    private void OnDrawGizmos()
    {
        //if object transform are set in the array, draw lines from our platforms to the location of start and end
        if (platformPosition[0] != null && platformPosition[1] != null && platformPosition[2] != null)
        {
            Gizmos.DrawLine(platformPosition[0].transform.position, platformPosition[1].transform.position);
            Gizmos.DrawLine(platformPosition[0].transform.position, platformPosition[2].transform.position);
        }

    }
}
