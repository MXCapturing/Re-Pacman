using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacDot : MonoBehaviour
{
    public int point;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Give points to player
            GameManager.instance.dotCount++;
            GameManager.instance.scoreText.text = GameManager.instance.score.ToString();
            Destroy(gameObject);
        }
    }
}
