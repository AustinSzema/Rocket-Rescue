using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectClick : MonoBehaviour
{

    //how about instead of making it a fixed size, just make it an endless thing until you crash
    //so instead of actually moving the rocket, just rotate it and only move it up and down
    //and then have a star background that moves or is animated to look like it's moving


    [SerializeField] private GameObject rocket;

    [SerializeField] private GameObject laserPrefab;

    private Camera cam;


    [SerializeField] private float rocketMoveDistance;


    private Vector2 originalRocketPos;

    [SerializeField] private DamageRocket dm;

    [SerializeField] private GameObject[] allButtons;

    [SerializeField] private List<Sprite> buttonSprites = new List<Sprite>();

    [SerializeField] private List<Sprite> startSprites;

    [SerializeField] private GameObject[] buttonIndicators;

    [SerializeField] private Slider laserCoolDownSlider;

    [Header("Sounds")]

    [SerializeField] private AudioSource asteroidExplosionSound;
    [SerializeField] private AudioSource buttonClickSound;
    [SerializeField] private AudioSource gameOverSound;
    [SerializeField] private AudioSource laserShootSound;



    private float coolDownTime = 0f;

    private bool decreaseCoolDownTime = true;

    [SerializeField] private SpriteRenderer LaserXSprite;
    private void Start()
    {
        cam = Camera.main;

        originalRocketPos = rocket.transform.position;

        foreach(Sprite buttonSprite in buttonSprites)
        {
            startSprites.Add(buttonSprite);
        }

    }

    //what if lets say you start out with 20 buttons in the bottom screen
    //when you click a button is moves transform completely
    //still trying to figure out the punishment for pressing the wrong button

    private void Update()
    {
        if(decreaseCoolDownTime == true)
        {
            coolDownTime -= Time.deltaTime;
            if(coolDownTime <= 0f)
            {
                coolDownTime = 0f;
            }
            laserCoolDownSlider.value = coolDownTime/5f;
        }
        //Debug.Log(coolDownTime);


        if(coolDownTime > 0f)
        {
            //Debug.Log("enabled X");
            LaserXSprite.enabled = true;
        }
        else
        {
            LaserXSprite.enabled = false;

        }

        if (Input.GetMouseButtonDown(0) && dm.countTime == true)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);


            if (hit.collider != null && Time.timeScale != 0f)
            {


                switch (hit.transform.gameObject.tag)
                {

                    case "Down Button":

                        if (rocket.transform.position.y > 0f)
                        {
                            buttonClickSound.Play();

                            rocket.transform.position = rocket.transform.position + new Vector3(0f, -rocketMoveDistance, 0f);

                            MoveButton();
                        }

                        break;

                    case "Up Button":

                        if (rocket.transform.position.y < 4f)
                        {

                            buttonClickSound.Play();

                            rocket.transform.position = rocket.transform.position + new Vector3(0f, rocketMoveDistance, 0f);

                            MoveButton();

                        }


                        break;

                    case "Laser Button":

                        if(coolDownTime <= 0f)
                        {
                            Instantiate(laserPrefab, new Vector3(rocket.transform.position.x, rocket.transform.position.y), Quaternion.identity);

                            laserShootSound.Play();

                            MoveButton();

                            coolDownTime = 5f;

                            decreaseCoolDownTime = true;

                        }

                        //when shoot laser but cooldown not over, dont move buttons or change sprites;


                        break;

                }


                ChangeButtonSprites();






                if (hit.transform.gameObject.tag == "KILL Button")
                {
                    Debug.Log("YOU ARE IS KILL");
                    Restart();
                }


            }
        }

    }



/*


    private IEnumerator DecreaseCoolDownTimer(float waitTime)
    {
        coolDownTime = coolDownTime - Time.deltaTime;

        yield return new WaitForSeconds(waitTime);
    }*/






    public void ChangeButtonSprites()
    {
        for (int i = 0; i < allButtons.Length - 1; i++)
        {
            int randomInt = Random.Range(0, buttonSprites.Count);
            allButtons[i].GetComponent<SpriteRenderer>().sprite = buttonSprites[randomInt];
            allButtons[i].GetComponent<PolygonCollider2D>().TryUpdateShapeToAttachedSprite();

            buttonIndicators[i].GetComponent<SpriteRenderer>().sprite = buttonSprites[randomInt];
            MoveButton();
            buttonSprites.Remove(buttonSprites[randomInt]);

        }

        buttonSprites.Clear();

        foreach (Sprite startSprite in startSprites)
        {
            buttonSprites.Add(startSprite);
        }
    }

    public void MoveButton()
    {

        foreach (GameObject button in allButtons)
        {
            float xPos = Random.Range(-2f, 4f);
            float yPos = Random.Range(-2f, -4f);

            button.transform.position = new Vector3(xPos, yPos);
            
        }

    }

    private void Restart()
    {

        float xBoundaryLeft = -3f;
        float xBoundaryRight = 3f;

        float yBoundaryTop = -2f;
        float yBoundaryBottom = -2.5f;

        foreach (GameObject button in allButtons)
        {

            Vector2 randomPos = new Vector2(Random.Range(xBoundaryLeft, xBoundaryRight), Random.Range(yBoundaryTop, yBoundaryBottom));


            button.transform.position = randomPos;

        }

        rocket.transform.position = originalRocketPos;


        Time.timeScale = 1f;



    }
}

