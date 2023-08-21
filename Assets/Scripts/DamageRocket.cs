using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageRocket : MonoBehaviour
{

    [SerializeField] private GameObject explosionEffect;


    [SerializeField] private GameObject timer;


    [SerializeField] private GameObject MeteorGenerator;

    [SerializeField] private CreateMeteor cm;

    [SerializeField] private GameObject RestartMenu;

    [SerializeField] private TextMeshProUGUI scoreCounter;

    [SerializeField] private CountScore cs;

    [SerializeField] private TextMeshProUGUI highScoreText;

    [SerializeField] private AudioSource gameOverSound;

    [SerializeField] private AudioSource backgroundMusic;

    
    private float highScore = 0f;

    public bool countTime = true;

    private Vector3 originalPos;


    private GameObject explosion;

    private bool timeFrozen = false;

    private string startingScoreText;

    private string startingHighScoreText;

    private void Start()
    {
        originalPos = transform.position;
        startingScoreText = scoreCounter.text;
        startingHighScoreText = highScoreText.text;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeFrozen)
        {
            if (Input.GetKeyDown("r"))
            {
                GetComponent<DetectClick>().MoveButton();
                GetComponent<DetectClick>().ChangeButtonSprites();


                GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");

                foreach (GameObject meteor in meteors)
                {
                    meteor.SetActive(false);
                }

                Restart();

                Destroy(explosion);


                timeFrozen = false;

                //MeteorGenerator.GetComponent<CreateMeteor>().spawnMeteors = true;

                countTime = true;

                //cm.callCoroutine();

                RestartMenu.SetActive(false);

                cs.score = 0f;

                scoreCounter.text = startingScoreText + "0";


                
            }
        }

        if(cs.score > highScore)
        {
            highScore = cs.score;
            highScoreText.text = startingHighScoreText + highScore;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Meteor")
        {
            explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

            gameOverSound.Play();

            GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");

            foreach (GameObject meteor in meteors)
            {

                meteor.GetComponent<MoveMeteor>().enabled = false;
                meteor.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

            cm.spawnMeteors = false;


            timeFrozen = true;
            countTime = false;

            backgroundMusic.Stop();

            RestartMenu.SetActive(true);

 
        }
    }



    private void Restart()
    {
        transform.position = originalPos;
        timer.GetComponent<CountTime>().timeCount = 0f;
        timeFrozen = false;
        cm.spawnMeteors = true;
        cm.spawnTime = cm.initialSpawnTime;
        backgroundMusic.Play();
    }




}
