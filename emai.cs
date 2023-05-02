using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emai : MonoBehaviour
{
    public Transform player;
    //reference for my waypoints
    public List<Transform> points;
    //the int value for my indexed list
    public int nextId;
    //declare a int to help us change our nextid
    private int idChangeValue = 1;
    //sets our speed of the emeny
    public float speed = 2;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < 5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            MoveToNextPoint();
        }
    }

    void MoveToNextPoint()
    {
        // declare and set a transform to our next point
        Transform goalPoint = points[nextId];
        //Flip the emeny via the transform to look at the points direction
        //Might need to change based off of the sprites natural face
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        //Move the emeny towards out point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //Check the distance between the emeny and the goalPoint to trigger the next point
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            //check if we are at the end of the line make our change value -1
            if (nextId == points.Count - 1)
            {
                idChangeValue = -1;
            }

            //check if we are the start of the line and make our change value 1
            if (nextId == 0)
            {
                idChangeValue = 1;
            }
            nextId += idChangeValue;
        }
    }
}
