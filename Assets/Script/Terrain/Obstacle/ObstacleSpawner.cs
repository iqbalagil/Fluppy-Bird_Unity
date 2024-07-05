using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float timeQueue = 1.5f;
    private float time = 0;
    private float height = 0.5f;
    public GameObject obstacle;
    public Transform obstaclePositon;
    public int destroyTime = 1;


    private Coroutine _returnToPoolTimerCoroutine;

    private void OnEnable()
    {
        _returnToPoolTimerCoroutine = StartCoroutine(ReturnToPoolAfterTime());
    }

    void Update()
    {
        if (time > timeQueue)
        {
            time = 0;
            var position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            ObjectPooledManager.SpawnObject(obstacle, position, Quaternion.identity);
            ObjectPooledManager.ReturnObjectToPool(gameObject);
        }
        time += Time.deltaTime;
    }
    private IEnumerator ReturnToPoolAfterTime()
    {
        float elapsedTime = 0f;
        while(elapsedTime < destroyTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        ObjectPooledManager.ReturnObjectToPool(gameObject);
    }
}
