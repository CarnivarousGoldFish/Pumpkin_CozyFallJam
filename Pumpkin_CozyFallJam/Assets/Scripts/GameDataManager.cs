using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager instance;

    public event Action onGameStart;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        Invoke("GameStart", 1f);

        
    }

    private void GameStart()
    {
        onGameStart?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
