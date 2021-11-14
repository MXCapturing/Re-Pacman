using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warppoints : MonoBehaviour
{
    public Transform warpPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 position = collision.transform.position;
        position.x = warpPoint.position.x;
        position.y = warpPoint.position.y;

        collision.transform.position = position;
    }
}
