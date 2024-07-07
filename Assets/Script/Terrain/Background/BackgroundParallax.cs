using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float parallaxEffectSpeed = 1f;
    public GameObject[] backgrounds;

    private float length;

    void Start()
    {
        length = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float dist = parallaxEffectSpeed * Time.deltaTime;

        foreach (GameObject background in backgrounds)
        {
            background.transform.position = new Vector3(background.transform.position.x - dist, background.transform.position.y, background.transform.position.z);

            if (background.transform.position.x <= -length)
            {
                float rightmostX = backgrounds[0].transform.position.x;
                foreach (GameObject bg in backgrounds)
                {
                    if (bg.transform.position.x > rightmostX)
                    {
                        rightmostX = bg.transform.position.x;
                    }
                }
                background.transform.position = new Vector3(rightmostX + length - 0.01f, background.transform.position.y, background.transform.position.z);
            }
        }
    }
}
