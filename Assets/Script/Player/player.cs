using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour, IDataPersistence
{
    Sound sound;

    public bool isDead;
    public GameManager gameManager;
    public float velocity = 1.5f;
    private Rigidbody2D rigidbodys;

    Transform bodyOrigin;
    Quaternion rotationOrigin;

    public static List<GameObject> coin = new List<GameObject>();
     int highScore;
     int coinScore;
    public Text scoreHighest;
    public Text score;

    //public float turnSpeed = 300f;
    //public float smoothRotation = 100f;
    //public Transform target;
    //private Transform myTransform;
    //private bool isReset;


    Quaternion upRotation;
    Quaternion downRotation;

    void Awake()
    {
        //myTransform = transform;
        sound = GameObject.FindGameObjectWithTag("Audio").GetComponent<Sound>();
    }

    void Start()
    {
        
        coinScore = 0;
        rigidbodys = GetComponent<Rigidbody2D>();
        rotationOrigin = bodyOrigin.rotation;

        float upAngle = -100.0f;
        float downAngle = 100.0f;
        upRotation = Quaternion.Euler(new Vector3(0, 0, upAngle));
        downRotation = Quaternion.Euler(new Vector3(0, 0, downAngle));

    }

    public void LoadData(GameData data)
    {
        this.highScore = data.scoreGame;
    }

    public void SaveData(ref GameData data)
    {
        data.scoreGame = this.highScore;
    }

    void Update()
    {



        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rigidbodys.velocity = Vector2.up;
        }

        if (rigidbodys.velocity.y > 0f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, Time.deltaTime * 5f );
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, upRotation, Time.deltaTime * 5f );
        }




        if (highScore < coinScore)
        {
            highScore = coinScore;
            scoreHighest.text = "" + coinScore;

        }

        //IEnumerator Reset()
        //{
        //    if (isReset) yield break;
        //    isReset = true;
        //    float timer = 0f;
        //    Quaternion startRot = transform.rotation;
        //    while (timer <= 1f)
        //    {
        //        transform.rotation = Quaternion.Lerp(startRot, transform.rotation.z(-10f), 2);
        //        yield return new WaitForEndOfFrame();
        //    }
        //    Debug.Log(timer);
        //    transform.rotation = target.rotation;
        //    isReset = false;
        //    yield break;
        //}
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        gameManager.GameOver();

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "coin10")
        {
            coinScore++;
            score.text = ($"{coinScore}");
            Destroy(other.gameObject, 0);
            sound.PlaySfx(sound.coinTouch);
        }

    }
}