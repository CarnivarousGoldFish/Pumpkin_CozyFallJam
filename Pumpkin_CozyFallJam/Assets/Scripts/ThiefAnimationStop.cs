using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefAnimationStop : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRend;
    private Animator animator;

    [SerializeField] private Sprite offSprite;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (boxCollider.enabled == false)
        {
            animator.enabled = false;
            spriteRend.sprite = offSprite;
        }
            
    }
}
