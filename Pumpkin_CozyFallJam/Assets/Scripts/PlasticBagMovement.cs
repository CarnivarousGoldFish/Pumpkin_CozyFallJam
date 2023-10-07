using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBagMovement : MonoBehaviour
{
    public static PlasticBagMovement instance;

    [SerializeField] private GameObject startPositionObj;
    [SerializeField] private GameObject exitObj;
    private Transform startPosition;
    private float movementPositionY;
    private float movementPositionX;

    private void Awake()
    {
        startPositionObj = GameObject.Find("Plastic Bag StartPosition");
        exitObj = GameObject.Find("Exit");
        startPosition = startPositionObj.transform;
    }

    private void Start()
    {
        transform.position = startPosition.position;
    }

    // Update is called once per frame
    private void Update()
    {

        movementPositionY = Mathf.Sin(Time.time);
        Debug.Log(movementPositionY);
        transform.position = new Vector3(transform.position.x, movementPositionY + startPosition.position.y, 0);
        transform.Translate(new Vector3(-3 * Time.deltaTime, 0, 0));

        if (transform.position.x < exitObj.transform.position.x)
            Exit();
    }

    private void Exit()
    {
        Destroy(this.gameObject);
    }
}
