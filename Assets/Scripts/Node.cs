using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask layerMask;
    public List<Vector2> avaliableDir { get; private set; }

    private void Start()
    {
        avaliableDir = new List<Vector2>();
        CheckDirections(Vector2.up);
        CheckDirections(Vector2.down);
        CheckDirections(Vector2.left);
        CheckDirections(Vector2.right);
    }

    void CheckDirections(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * .5f, 0f, direction, 1, layerMask);

        if(hit.collider == null)
        {
            avaliableDir.Add(direction);
        }
    }
}
