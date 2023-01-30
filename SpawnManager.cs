using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public GameObject[] pointPrefab;
    public TextMeshPro scoreText;
    
    private Quaternion objectRotation = Quaternion.Euler(120, 135, 65);
    private float xRange = 35f;
    private float zPos1 = -8f;
    private float zPos2 = 0f;
    private float zPos3 = 8f;
    private float startDelay = 2f;
    private int score = 0;
    private int shapeOne;
    private int shapeTwo;
    private int shapeThree; 


    private float xRangePoints = 12f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomCar", startDelay);
        SpawnPoints();
    }

    // Update is called once per frame
    void Update()
    {
        shapeOne = GameObject.FindGameObjectsWithTag("Shape 1").Length;
        shapeTwo = GameObject.FindGameObjectsWithTag("Shape 2").Length;
        shapeThree = GameObject.FindGameObjectsWithTag("Shape 3").Length;
        if ((shapeOne + shapeTwo + shapeThree) < 3)
        {
            SpawnPoints();
        }

    }

    void SpawnRandomCar()
    {
        int randomIndex1 = Random.Range(0, carPrefabs.Length);
        int randomIndex2 = Random.Range(0, carPrefabs.Length);
        int randomIndex3 = Random.Range(0, carPrefabs.Length);

        float spawnInterval = Random.Range(1f, 3f);
        Vector3 spawnRotate = new Vector3(0, -180, 0);

        Vector3 spawnPosLeft1 = new Vector3(-xRange, 0, zPos1);
        Vector3 spawnPosRight = new Vector3(xRange, 0, zPos2);
        Vector3 spawnPosLeft2 = new Vector3(-xRange, 0, zPos3);

        Instantiate(carPrefabs[randomIndex1], spawnPosLeft1, carPrefabs[randomIndex1].transform.rotation);
        Instantiate(carPrefabs[randomIndex2], spawnPosRight, Quaternion.Euler(spawnRotate));
        Instantiate(carPrefabs[randomIndex3], spawnPosLeft2, carPrefabs[randomIndex3].transform.rotation);

        Invoke("SpawnRandomCar", spawnInterval);
    }

    void SpawnPoints()
    {
        Vector3 pointSpawnPos = new Vector3((Random.Range(-xRangePoints, xRangePoints)), 8, 25);

        int randomPointPrefab = Random.Range(0, pointPrefab.Length);

        Instantiate(pointPrefab[randomPointPrefab], pointSpawnPos, objectRotation);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "SCORE: " + score;
    }
}