using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HazardManager : MonoBehaviour
{

    [SerializeField] private GameObject[] hazardPrefab;
    [SerializeField] private GameObject candyStore;
    //[SerializeField] private TextMeshProUGUI gameTimerText;

    private float gameTimer = 2f;//GameTimer

    //public static HazardManager instance;

    private float hazardSpawnInterval = 10;
    private float hazardSpawnReset = 10;

    private bool isGameStart = false;
    private bool isGameEnd = false;

    
    private void Awake()
    {
        //instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GameDataManager.instance.onGameStart += StartTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStart)
            return;

        
        if (hazardSpawnInterval < 0)
        {
            Debug.Log("HAZARD INCOMMING");
            hazardSpawnInterval = hazardSpawnReset;
            int min = 0;
            int max = hazardPrefab.Length;
            Instantiate(hazardPrefab[UnityEngine.Random.Range(min, max)], new Vector3(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10), 0), Quaternion.identity);
            /*
            int index = Random.Range(0, hazardPrefab.Length);
            hazardPrefab[index].SetActive(true);
            //*/

            
        }

        if (isGameEnd)
        {
            candyStore.SetActive(true);
        }


    }

    private void StartTimer()
    {
        StartCoroutine(GameTimer());

    }


    private IEnumerator GameTimer()
    {
        Debug.Log("GAME START");
        
        isGameStart = true;
        

        while (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
            hazardSpawnInterval -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(gameTimer / 60);
            //Debug.Log(minutes);

            float seconds = Mathf.FloorToInt(hazardSpawnInterval % 60);

           // Debug.Log(seconds);

            

            //gameTimerText.text = minutes.ToString();
            //if(minutes)
            //*
            if (minutes >= 3f)
            {
                hazardSpawnReset = 6f;
                Debug.Log("STAGE 1");
            }
            else if(minutes >= 1f && minutes < 3f)
            {
                hazardSpawnReset = 4f;
                Debug.Log("STAGE 2");
            }
            else if (minutes < 1f)
            {
                hazardSpawnReset = 2f;
                Debug.Log("STAGE 3");
            }

            
            //*/
            yield return null;

        }
        Debug.Log("END");
        isGameEnd = true;

    }
    
}
