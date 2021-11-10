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
            GameManager.instance.points += point;
            GameManager.instance.pointText.text = GameManager.instance.points.ToString();
            Destroy(gameObject);
        }
    }
}