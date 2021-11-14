using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostsHome : GhostBehaviour
{
    public Transform inside;
    public Transform outside;

    private void OnEnable()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(ExitTransition());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(enabled && collision.gameObject.CompareTag("Wall"))
        {
            ghost.movement.SetDirection(-ghost.movement.direction);
        }
    }

    IEnumerator ExitTransition()
    {
        ghost.movement.SetDirection(Vector2.up, true);
        ghost.movement._rb.isKinematic = true;
        ghost.movement.enabled = false;

        Vector3 position = transform.position;

        float duration = 0.5f;
        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            Vector3 newPos = Vector3.Lerp(position, inside.position, elapsed/duration);
            newPos.z = position.z;
            ghost.transform.position = newPos;
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;

        while (elapsed < duration)
        {
            Vector3 newPos = Vector3.Lerp(inside.position, outside.position, elapsed / duration);
            newPos.z = position.z;
            ghost.transform.position = newPos;
            elapsed += Time.deltaTime;
            yield return null;
        }

        ghost.movement.SetDirection(new Vector2(Random.value < 0.5f ? -1.0f : 1.0f, 0f), true);
        ghost.movement._rb.isKinematic = false;
        ghost.movement.enabled = true;
    }
}
