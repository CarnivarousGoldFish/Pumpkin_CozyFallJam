using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HazardManager : MonoBehaviour
{

    [SerializeField] private GameObject[] hazardPrefab;
    [SerializeField] private GameObject candyStore;
    [SerializeField] private PlaySFX[] playSFX;
    //[SerializeField] private TextMeshProUGUI gameTimerText;

    private int lastIndex = 0;

    private float gameTimer = 180f;//GameTimer

    //public static HazardManager instance;

    private float hazardSpawnInterval = 6;
    private float hazardSpawnReset = 6;

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

        
        if (hazardSpawnInterval < 0 && !isGameEnd)
        {
            Debug.Log("HAZARD INCOMMING");
            hazardSpawnInterval = hazardSpawnReset;
            int min = 0;
            int max = hazardPrefab.Length;
            int index = UnityEngine.Random.Range(min, max);

            while (index == lastIndex)
            {
                index = UnityEngine.Random.Range(min, max);
            }

            Instantiate(hazardPrefab[index], new Vector3(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10), 0), Quaternion.identity);

            if(index != 0)
                playSFX[index].Play();

            lastIndex = index;
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
            if (minutes >= 2f)
            {
                hazardSpawnReset = 6f;
                Debug.Log("STAGE 1");
            }
            else if(minutes >= 1f && minutes < 2f)
            {
                hazardSpawnReset = 5f;
                Debug.Log("STAGE 2");
            }
            else if (minutes < 1f)
            {
                hazardSpawnReset = 4f;
                Debug.Log("STAGE 3");
            }

            
            //*/
            yield return null;

        }
        Debug.Log("END");
        isGameEnd = true;

    }
    
}
