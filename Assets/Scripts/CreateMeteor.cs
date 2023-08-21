using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMeteor : MonoBehaviour
{


    [SerializeField] private GameObject RocketContainer;

    public bool spawnMeteors = true;

    [SerializeField] private GameObject MeteorPrefab;



    [SerializeField] private GameObject Lane1;
    [SerializeField] private GameObject Lane2;
    [SerializeField] private GameObject Lane3;

    [SerializeField] private ObjectPool meteorObjectPool;

//    [SerializeField] private float spawnTime;


    //public IEnumerator coroutine;


    public void SpawnMeteor()
    {

        if (spawnMeteors == true)
        {





            switch (RocketContainer.transform.position.y)
            {
                case 4f:
                    GameObject playerAttackMeteor1 = Instantiate(MeteorPrefab, Lane1.transform.position, Quaternion.identity);

                    break;

                case 2f:

                    GameObject playerAttackMeteor2 = Instantiate(MeteorPrefab, Lane2.transform.position, Quaternion.identity);

                    break;


                case 0f:

                    GameObject playerAttackMeteor3 = Instantiate(MeteorPrefab, Lane3.transform.position, Quaternion.identity);

                    break;
            }

            Vector3 meteorSpawnPosition = Lane2.transform.position;

            int laneChoice = Random.Range(1, 4);

            //Debug.Log(laneChoice);

            switch (laneChoice)
            {
                case 1:

                    meteorSpawnPosition = Lane1.transform.position;
                    break;


                case 2:

                    meteorSpawnPosition = Lane2.transform.position;
                    break;

                case 3:

                    meteorSpawnPosition = Lane3.transform.position;
                    break;
            }




            GameObject meteor = meteorObjectPool.GetPooledObject();
            if (meteor != null)
            {
                meteor.SetActive(true);
                meteor.transform.position = meteorSpawnPosition;
            }

            //            GameObject meteor = Instantiate(MeteorPrefab, meteorSpawnPosition, Quaternion.identity);

        }
    }

    public float initialSpawnTime = 5f; // Time between spawns at start
    public float spawnTimeDecrement = 0.1f; // Amount to decrement spawn time each spawn
    public float minSpawnTime = 1f; // Minimum time between spawns

    public float spawnTime; // Current time between spawns
    private float spawnTimer; // Timer for spawning objects

    private void Start()
    {
        spawnTime = initialSpawnTime;
        spawnTimer = spawnTime;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnMeteor();
            spawnTime -= spawnTimeDecrement;
            spawnTime = Mathf.Max(spawnTime, minSpawnTime);
            spawnTimer = spawnTime;
        }
    }

    
}
