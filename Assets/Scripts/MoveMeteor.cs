using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeteor : MonoBehaviour
{
    [SerializeField] private GameObject meteorContainer;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float meteorSpeed;

    [SerializeField] private GameObject rocketContainer;

    [SerializeField] private float destroyMeteorXPos = -3.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(meteorContainer.transform.position.x < destroyMeteorXPos)
        {
            meteorContainer.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-meteorSpeed, 0f);
    }


   
}
