using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScatter : GhostBehaviour
{
    private void OnDisable()
    {
        ghost.chase.Enable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if(node != null && enabled && !ghost.frightened.enabled)
        {
            int index = Random.Range(0, node.avaliableDir.Count);
            if(node.avaliableDir[index] == -ghost.movement.direction && node.avaliableDir.Count > 1)
            {
                index++;

                if(index >= node.avaliableDir.Count)
                {
                    index = 0;
                }
            }

            ghost.movement.SetDirection(node.avaliableDir[index]);
        }
    }
}
