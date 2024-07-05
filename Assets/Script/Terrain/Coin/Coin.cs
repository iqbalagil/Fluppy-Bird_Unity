using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float time = 0;
    public float queueTime = 1.5f;
    public float height;
    public GameObject coin;

    void Update()
    {
        if (time > queueTime)
        {
            time = 0;
            var position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            GameObject go = Instantiate(coin, coin.transform.position, Quaternion.identity);
            Destroy(go, 10);
        }
        time += Time.deltaTime;

    }
}
