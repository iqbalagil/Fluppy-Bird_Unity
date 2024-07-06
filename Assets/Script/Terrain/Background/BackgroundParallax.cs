using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    private float startPos, length;
    public GameObject cam;
    public float parallaxBg;
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = cam.transform.position.x * parallaxBg;
        float movement = cam.transform.position.x * (1 - parallaxBg);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (movement >startPos + length)
        {
            startPos += length;
        } else if (movement < startPos - length)
        {
            startPos -= length;
        }
    }
}
