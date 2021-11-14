using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChase : GhostBehaviour
{
    private void OnDisable()
    {
        ghost.scatter.Enable();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if (node != null && enabled && !ghost.frightened.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            foreach(Vector2 avaliableDir in node.avaliableDir)
            {
                Vector3 newPos = transform.position + new Vector3(avaliableDir.x, avaliableDir.y);
                float distance = (ghost.target.position - newPos).sqrMagnitude;

                if(distance < minDistance)
                {
                    direction = avaliableDir;
                    minDistance = distance;
                }
            }

            ghost.movement.SetDirection(direction);
        }
    }
}
