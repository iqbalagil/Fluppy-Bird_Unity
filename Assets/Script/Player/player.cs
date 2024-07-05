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

    public List<GameObject> coin = new List<GameObject>();
     int highScore;
     int coinScore;
    public Text scoreHighest;
    public Text score;
    private bool hasTriggered;

    void Start()
    {
        coinScore = 0;
        rigidbodys = GetComponent<Rigidbody2D>();
        sound = GameObject.FindGameObjectWithTag("Audio").GetComponent<Sound>();

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
        if (Input.GetKey(KeyCode.Mouse0)){

            rigidbodys.velocity = Vector2.up * velocity;
            sound.PlaySfx(sound.jump);
            
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
        if (other.CompareTag("coin10"))
        {
            //Debug.Log("coin is triggered");
            coinScore++;
            score.text = ($"{coinScore}");
            Destroy(other.gameObject, 0);
            sound.PlaySfx(sound.coinTouch);
        }
    }
}