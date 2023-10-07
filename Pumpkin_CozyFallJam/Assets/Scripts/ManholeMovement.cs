using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManholeMovement : MonoBehaviour
{
    [SerializeField] private GameObject startPositionObj;
    [SerializeField] private GameObject exitObj;
    private Transform startPosition;
    private float moveSpeed = 3;

    private void Awake()
    {
        startPositionObj = GameObject.Find("Manhole StartPosition");
        exitObj = GameObject.Find("Exit");
        startPosition = startPositionObj.transform;
    }

    private void Start()
    {
        transform.position = startPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1.75f * Time.deltaTime, 0, 0));

        if (transform.position.x < exitObj.transform.position.x)
            Exit();
    }

    private void Exit()
    {
        Destroy(this.gameObject);
    }
}
