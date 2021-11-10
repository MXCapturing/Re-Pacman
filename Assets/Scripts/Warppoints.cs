using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warppoints : MonoBehaviour
{
    public Vector3 warpPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.position = warpPoint;
        }
    }
}
