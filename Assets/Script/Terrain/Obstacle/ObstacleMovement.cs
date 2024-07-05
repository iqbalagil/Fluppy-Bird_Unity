using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 1f;

    void Start()
    {
        
    }


    void Update()
    {
        transform.position += ((Vector3.left * speed) * Time.deltaTime);
    }
}
