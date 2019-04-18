using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyPlanetController : MonoBehaviour
{

    public float enemyminSpawnTime = 0.75f;
    public float enemymaxSpawnTime = 2f;
    public GameObject enemyPlanetPrefab;
    private int enemyspawnCounter = 0;

    // Start is called before the first frame update
    void Start()
    {


        Invoke("SpawnGPlanet", enemyminSpawnTime);
        enemyspawnCounter = enemyspawnCounter - 1;


    }



    void SpawnGPlanet()
    {
        Camera camera = Camera.main;
        Vector3 cameraPos = camera.transform.position;
        float xMax = camera.aspect * camera.orthographicSize;
        float xRange = camera.aspect * camera.orthographicSize * 1.75f;
        float yMax = camera.orthographicSize - 0.5f;
        float yRange = camera.aspect * camera.orthographicSize * 1.75f;


        Vector3 enemyPlanetPos = new Vector3(cameraPos.x + Random.Range(xMax - xRange, xMax), Random.Range(yMax-yRange, yMax), enemyPlanetPrefab.transform.position.z);
        Instantiate(enemyPlanetPrefab, enemyPlanetPos, Quaternion.identity);




        Invoke("SpawnGPlanet", Random.Range(enemyminSpawnTime, enemymaxSpawnTime));





    }


}
