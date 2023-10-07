using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleClick : MonoBehaviour
{

    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private double doubleClickTimer = 0.25f;
    private bool isDoubleClicking = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer.sprite = onSprite;
    }

    private void Update()
    {
        if (isDoubleClicking)
        {
            boxCollider.enabled = false;
            spriteRenderer.sprite = offSprite;
        }

    }

    private IEnumerator MouseClick()
    {
        yield return new WaitForEndOfFrame();

        float timeCount = 0;

        while(timeCount < doubleClickTimer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DoubleClick();
                yield break;
            }

            timeCount += Time.deltaTime;
            yield return null;
        }

        //SingleClick;
    }

    private void DoubleClick()
    {
        isDoubleClicking = true;

        Debug.Log("IS DOUBLE CLICKING :: " + isDoubleClicking);
    }

    private void OnMouseDown()
    {
        //Debug.Log("OBJECT CLICKED");
        StartCoroutine(MouseClick());
    }

    private void OnMouseUp()
    {
        isDoubleClicking = false;
        Debug.Log("IS DOUBLE CLICKING :: " + isDoubleClicking);
    }

}
