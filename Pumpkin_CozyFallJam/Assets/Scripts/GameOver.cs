using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private float winnerScreenTimerTick;
    [SerializeField] private GameObject winnerText;
    [SerializeField] private GameObject winnerOverlay;
    [SerializeField] private Image winnerImage;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite shockSprite;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource audioSrc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            anim.enabled = false;
            spriteRenderer.sprite = shockSprite;
            audioSrc.Stop();
            StartCoroutine(WinnerWinnerChickenDinner());
        }
    }

    IEnumerator WinnerWinnerChickenDinner()
    {
        winnerOverlay.SetActive(true);

        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            winnerScreenTimerTick++;
            winnerImage.fillAmount = winnerScreenTimerTick * 0.01f;

        }

        winnerText.SetActive(true);
        yield return new WaitForSeconds(1f);
    }
}
