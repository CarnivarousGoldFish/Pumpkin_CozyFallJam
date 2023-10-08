using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCandyStore : MonoBehaviour
{
    public static MoveCandyStore instance;

    public event Action EndGame;

    [SerializeField] private Transform end;
    // Update is called once per frame

    private void Awake()
    {
        instance = this;
    }


    void Update()
    {
        transform.Translate(new Vector3(-3f * Time.deltaTime, 0, 0));
        if (transform.position.x < end.position.x)
        {
            EndGame?.Invoke();
        }
    }

    
}
