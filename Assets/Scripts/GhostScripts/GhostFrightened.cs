using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFrightened : GhostBehaviour
{
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer blue;
    public SpriteRenderer white;

    public bool eaten { get; private set; }

    public override void Enable(float duration)
    {
        base.Enable(duration);

        body.enabled = false;
        eyes.enabled = false;
        blue.enabled = true;
        white.enabled = false;

        Invoke(nameof(Flash), duration / 2);
    }

    public override void Disable()
    {
        base.Disable();

        body.enabled = true;
        eyes.enabled = true;
        blue.enabled = false;
        white.enabled = false;
    }

    void Flash()
    {
        if (!eaten)
        {
            blue.enabled = false;
            white.enabled = true;
            white.GetComponent<AnimatedSprite>().Restart();
        }
    }

    void Eaten()
    {
        eaten = true;

        Vector3 position = ghost.home.inside.position;
        position.z = ghost.transform.position.z;
        ghost.transform.position = position;

        ghost.home.Enable(duration);

        body.enabled = false;
        eyes.enabled = true;
        blue.enabled = false;
        white.enabled = false;
    }

    private void OnEnable()
    {
        ghost.movement.speedMultiplier = .5f;
        eaten = false;
    }

    private void OnDisable()
    {
        ghost.movement.speedMultiplier = 1;
        eaten = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (enabled)
            {
                Eaten();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if (node != null && enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            foreach (Vector2 avaliableDir in node.avaliableDir)
            {
                Vector3 newPos = transform.position + new Vector3(avaliableDir.x, avaliableDir.y);
                float distance = (ghost.target.position - newPos).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = avaliableDir;
                    maxDistance = distance;
                }
            }

            ghost.movement.SetDirection(direction);
        }
    }
}