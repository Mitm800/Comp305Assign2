using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    public Transform position1;
    public Transform position2;

    public float speed = 3.0f;
    private Vector3 nextPosition;
    
    void Start()
    {
        nextPosition = position2.position;
    }

    void Update()
    {
        if(transform.position == position1.position)
        {
            nextPosition = position2.position;
        }
        if(transform.position == position2.position)
        {
            nextPosition = position1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(position1.position, position2.position);
    }
}
