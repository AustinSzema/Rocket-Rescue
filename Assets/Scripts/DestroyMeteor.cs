using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyMeteor : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float laserSpeed;


    [SerializeField] private AudioSource asteroidExplosionSound;

    [SerializeField] private GameObject meteorExplodeParticles;
        
    private GameObject ScoreCounterObject;

    private Vector3 particlePos;

    private void Start()
    {
        ScoreCounterObject = GameObject.Find("Score");
        
    }



    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(laserSpeed, 0f);

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Meteor")
        {
            asteroidExplosionSound.Play();
            collision.gameObject.SetActive(false);

            particlePos = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, 0f);

            Instantiate(meteorExplodeParticles, particlePos, Quaternion.identity);

            ScoreCounterObject.GetComponent<CountScore>().AddPoints();
        }
    }
}
