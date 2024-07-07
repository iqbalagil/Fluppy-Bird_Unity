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
        float angle = Mathf.Lerp(0, -90, -rigidbodys.velocity.y / 7f);
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rigidbodys.velocity = Vector2.up * velocity;
            float angleUp = Mathf.Lerp(0, 90, rigidbodys.velocity.y / 7f) ;
            transform.rotation = Quaternion.Euler(0, 0, angleUp);
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