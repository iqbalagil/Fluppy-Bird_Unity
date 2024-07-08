using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomRange : MonoBehaviour
{
    public float startTime = 0;
    public float speedChange = 0.01f;
    public GameObject obstaclesUp;
    public GameObject obstacleDown;
    public float height = 0.2f;
    private float desiredDuration = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        float randChance = Random.value;
        if (other.tag == "Player"){

            startTime = Time.time;

            if (randChance < .45f)
            {
                var fromPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                var toPosition = new Vector3(transform.position.x, Random.Range(-1f, -0f), transform.position.z);

                //float positionLenght = Vector3.Distance(fromPosition, toPosition);
                float distancePerFrame = speedChange * Time.deltaTime;

                //float endDistancePerFrame = distancePerFrame / positionLenght;
                obstaclesUp.transform.position = Vector3.MoveTowards(toPosition, fromPosition, distancePerFrame);
            }
            if (randChance < .9)
            {
                Debug.Log("Change Position Bottom Pipe");
                var startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                var endPosition = new Vector3(transform.position.x, Random.Range(1.2f, 2f), transform.position.z);

                float distancePerFrame = speedChange * Time.deltaTime;

                //float endDistancePerFrame = distancePerFrame / desiredDuration;

                obstacleDown.transform.position = Vector3.MoveTowards(endPosition, startPosition, distancePerFrame);

            }
        }
    }
}