using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButtonArt : MonoBehaviour
{

    [SerializeField] private CountScore cs;

    [SerializeField] private SpriteRenderer UpButton;
    [SerializeField] private SpriteRenderer DownButton;
    [SerializeField] private SpriteRenderer LaserButton;

    [SerializeField] private Sprite[] buttonSprites;


    private bool changeTheSprites = false;

    private void Update()
    {

        if(cs.score % 2 == 0){

            if(cs.score != 0 && changeTheSprites == false)
            {
                ChangeSprite();
            }
            changeTheSprites = true;



        }
    }



    private void ChangeSprite()
    {
        UpButton.sprite = buttonSprites[Random.Range(0, buttonSprites.Length)];
        DownButton.sprite = buttonSprites[Random.Range(0, buttonSprites.Length)];
        LaserButton.sprite = buttonSprites[Random.Range(0, buttonSprites.Length)];

    }
}
